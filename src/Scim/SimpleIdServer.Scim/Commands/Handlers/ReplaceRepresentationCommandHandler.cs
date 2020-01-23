﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.Scim.Domain;
using SimpleIdServer.Scim.Exceptions;
using SimpleIdServer.Scim.Extensions;
using SimpleIdServer.Scim.Helpers;
using SimpleIdServer.Scim.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleIdServer.Scim.Commands.Handlers
{
    public class ReplaceRepresentationCommandHandler : IReplaceRepresentationCommandHandler
    {
        private readonly ISCIMSchemaQueryRepository _scimSchemaQueryRepository;
        private readonly ISCIMRepresentationQueryRepository _scimRepresentationQueryRepository;
        private readonly ISCIMRepresentationHelper _scimRepresentationHelper;
        private readonly ISCIMRepresentationCommandRepository _scimRepresentationCommandRepository;

        public ReplaceRepresentationCommandHandler(ISCIMSchemaQueryRepository scimSchemaQueryRepository, ISCIMRepresentationQueryRepository scimRepresentationQueryRepository, ISCIMRepresentationHelper scimRepresentationHelper, ISCIMRepresentationCommandRepository scimRepresentationCommandRepository)
        {
            _scimSchemaQueryRepository = scimSchemaQueryRepository;
            _scimRepresentationQueryRepository = scimRepresentationQueryRepository;
            _scimRepresentationHelper = scimRepresentationHelper;
            _scimRepresentationCommandRepository = scimRepresentationCommandRepository;
        }

        public async Task<SCIMRepresentation> Handle(ReplaceRepresentationCommand replaceRepresentationCommand)
        {
            var requestedSchemas = replaceRepresentationCommand.Representation.GetSchemas();
            if (!requestedSchemas.Any())
            {
                throw new SCIMBadRequestException("invalidRequest", $"{SCIMConstants.StandardSCIMRepresentationAttributes.Schemas} attribute is missing");
            }

            var schema = await _scimSchemaQueryRepository.FindRootSCIMSchemaByResourceType(replaceRepresentationCommand.ResourceType);
            var allSchemas = new List<string> { schema.Id };
            allSchemas.AddRange(schema.SchemaExtensions.Select(s => s.Schema));
            var unsupportedSchemas = requestedSchemas.Where(s => !allSchemas.Contains(s));
            if (unsupportedSchemas.Any())
            {
                throw new SCIMBadRequestException("invalidRequest", $"the schemas {string.Join(",", unsupportedSchemas)} are unknown");
            }

            var schemas = await _scimSchemaQueryRepository.FindSCIMSchemaByIdentifiers(requestedSchemas);
            var existingRepresentation = await _scimRepresentationQueryRepository.FindSCIMRepresentationById(replaceRepresentationCommand.Id);
            if (existingRepresentation == null)
            {
                throw new SCIMNotFoundException("notFound", "Resource does not exist");
            }

            var updatedRepresentation = _scimRepresentationHelper.ExtractSCIMRepresentationFromJSON(replaceRepresentationCommand.Representation, schemas.ToList());
            foreach(var updatedAttribute in updatedRepresentation.Attributes)
            {
                if (updatedAttribute.SchemaAttribute.Mutability == SCIMSchemaAttributeMutabilities.IMMUTABLE)
                {
                    throw new SCIMImmutableAttributeException($"attribute {updatedAttribute.Id} is immutable");
                }

                if (updatedAttribute.SchemaAttribute.Mutability == SCIMSchemaAttributeMutabilities.WRITEONLY || updatedAttribute.SchemaAttribute.Mutability == SCIMSchemaAttributeMutabilities.READWRITE)
                {
                    var existingAttribute = existingRepresentation.Attributes.FirstOrDefault(a => a.SchemaAttribute.Id == updatedAttribute.SchemaAttribute.Id);
                    if (existingAttribute == null)
                    {
                        existingRepresentation.AddAttribute(updatedAttribute);
                    }
                    else
                    {
                        existingRepresentation.Attributes.Remove(existingAttribute);
                        existingRepresentation.AddAttribute(updatedAttribute);
                    }
                }
            }

            existingRepresentation.SetUpdated(DateTime.UtcNow);
            _scimRepresentationCommandRepository.Update(existingRepresentation);
            await _scimRepresentationCommandRepository.SaveChanges();
            return existingRepresentation;
        }
    }
}
