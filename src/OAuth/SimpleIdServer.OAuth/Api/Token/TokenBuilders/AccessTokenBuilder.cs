﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Newtonsoft.Json.Linq;
using SimpleIdServer.Jwt.Jws;
using SimpleIdServer.OAuth.DTOs;
using SimpleIdServer.OAuth.Extensions;
using SimpleIdServer.OAuth.Helpers;
using SimpleIdServer.OAuth.Jwt;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleIdServer.OAuth.Api.Token.TokenBuilders
{
    public class AccessTokenBuilder : ITokenBuilder
    {
        private readonly IGrantedTokenHelper _grantedTokenHelper;
        private readonly IJwtBuilder _jwtBuilder;

        public AccessTokenBuilder(IGrantedTokenHelper grantedTokenHelper, IJwtBuilder jwtBuilder)
        {
            _grantedTokenHelper = grantedTokenHelper;
            _jwtBuilder = jwtBuilder;
        }

        public string Name => TokenResponseParameters.AccessToken;

        public async virtual Task Build(IEnumerable<string> scopes, HandlerContext handlerContext, CancellationToken cancellationToken)
        {
            var jwsPayload = BuildPayload(scopes, handlerContext);
            await SetResponse(handlerContext, jwsPayload, cancellationToken);
        }

        public virtual Task Refresh(JObject previousRequest, HandlerContext currentContext, CancellationToken cancellationToken)
        {
            var scopes = previousRequest.GetScopesFromAuthorizationRequest();
            return Build(scopes, currentContext, cancellationToken);
        }

        protected JwsPayload BuildPayload(IEnumerable<string> scopes, HandlerContext handlerContext)
        {
            var jwsPayload = _grantedTokenHelper.BuildAccessToken(new[]
            {
                handlerContext.Client.ClientId
            }, scopes, handlerContext.Request.IssuerName, handlerContext.Client.TokenExpirationTimeInSeconds);
            return jwsPayload;
        }

        protected async Task SetResponse(HandlerContext handlerContext, JwsPayload jwsPayload, CancellationToken cancellationToken)
        {
            var authorizationCode = string.Empty;
            if (!handlerContext.Response.TryGet(AuthorizationResponseParameters.Code, out authorizationCode))
            {
                authorizationCode = handlerContext.Request.Data.GetAuthorizationCode();
            }

            var accessToken = await _jwtBuilder.BuildAccessToken(handlerContext.Client, jwsPayload);
            await _grantedTokenHelper.AddAccessToken(accessToken, handlerContext.Client.ClientId, authorizationCode, cancellationToken);
            handlerContext.Response.Add(TokenResponseParameters.AccessToken, accessToken);
        }
    }
}