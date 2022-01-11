@model SimpleIdServer.Uma.UI.ViewModels.ResourcesIndexViewModel
@using Microsoft.AspNetCore.Localization
@using Microsoft.AspNetCore.Mvc.Localization
@inject IViewLocalizer Localizer

@{
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.Title = Localizer["my_resources_title"];
    var requestCulture = Context.Features.Get<IRequestCultureFeature>();
}

<div class="container">
    <h1>@Localizer["my_resources_title"]</h1>
    <table class="table table-striped table-bordered" id="my-resources">
        <thead>
            <tr>
                <th>@Localizer["name"]</th>
                <th>@Localizer["description"]</th>
                <th>@Localizer["scopes"]</th>
                <th>@Localizer["creation_datetime"]</th>
                <th></th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>

@section Scripts {
    <script type="text/javascript">
        $(document).ready(function () {
            let currentCultureKey = "@requestCulture.RequestCulture.UICulture.Name";
            let editResourceUrl = "@Url.Action("Edit", "Resources")";
            $("#my-resources").DataTable({
                "processing": true,
                "serverSide": true,
                "searching": false,
                "ajax": {
                    "url": "@Url.Action("SearchMe", "ResourcesAPI")",
                    "type": "GET",
                    "data": function (d) {
                        let orderColumnSort = d.order[0].dir;
                        let orderColumnIndex = d.order[0].column;
                        let orderColumnName = d.columns[orderColumnIndex].name;
                        var query = "start_index=" + d.start + "&count=" + d.length + "&sort=" + orderColumnName + "&order=" + orderColumnSort;
                        return query;
                    },
                    "beforeSend": function (xhr) {
                        xhr.setRequestHeader("Authorization", "@Model.IdToken");
                    },
                    "dataFilter": function (inData) {
                        let json = JSON.parse(inData);
                        let newData = [];
                        json.data.forEach(function (jObj) {
                            var newObj = [];
                            let name = "", description = "";
                            for (var jObjKey in jObj) {
                                if (jObjKey.startsWith('name') || jObjKey.startsWith('description')) {
                                    let splittedKey = jObjKey.split('#');
                                    if (splittedKey[1] === currentCultureKey) {
                                        if (splittedKey[0] === 'name') {
                                            name = jObj[jObjKey];
                                        }
                                        else if (splittedKey[0] === 'description') {
                                            description = jObj[jObjKey];
                                        }
                                    }
                                }
                            }

                            newObj.push(name);
                            newObj.push(description);
                            newObj.push(jObj["resource_scopes"].join());
                            newObj.push(jObj["create_datetime"]);
                            newObj.push(jObj["_id"]);
                            newData.push(newObj);
                        });
                        var result = {
                            data: newData,
                            recordsTotal: json.totalResults,
                            recordsFiltered: json.totalResults
                        };
                        return JSON.stringify(result);
                    }
                },
                "columnDefs": [
                    { "name": "Name", targets: 0, orderable: false },
                    { "name": "Description", targets: 1, orderable: false },
                    { "name": "Scopes", targets: 2, orderable: false },
                    { "name": "CreateDateTime", targets: 3 },
                    {
                        "name": "Action", targets: 4, orderable: false, render: function (data) {
                            let url = editResourceUrl + "/" + data;
                            return "<a href='" + url + "' class='btn btn-primary'>Edit</a>";
                        }}
                ],
                "order": [[3, "desc"]]
            });
        });
    </script>
}