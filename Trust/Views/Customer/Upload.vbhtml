@ModelType System.Data.DataTable
@Imports System.Data
@Code
    ViewData("Title") = "Upload"
End Code

<h2>Upload</h2>

@Using (Html.BeginForm("Upload", "Customer", Nothing, FormMethod.Post, htmlAttributes:=New With {.enctype = "multipart/form-data"}))
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

    @<div Class="form-group">
        <input type="file" id="dataFile" name="uploaded" />
    </div>

    @<div Class="form-group">
        <input type="submit" value="Upload" Class="btn btn-default" />
    </div>
    if (Model IsNot Nothing) Then
        @<div Class="box">
            <div Class="box-body table-responsive no-padding">
                <Table id="detailsTable" Class="table table-hover">
                    <thead>
                        <tr>
                            @For Each col In Model.Columns
                                @<th>@col.ColumnName</th>
                            Next

                        </tr>
                    </thead>
                    <tbody>
                        @For Each row In Model.Rows
                            @<tr>
                                @For Each col In Model.Columns
                                    @<td>@row(col.ColumnName)</td>
                                Next
                            </tr>
                        Next
                    </tbody>
                </Table>
            </div>
        </div>
    End If
End Using
