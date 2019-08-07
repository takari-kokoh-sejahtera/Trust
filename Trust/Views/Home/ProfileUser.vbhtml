@Code
    ViewData("Title") = "ProfileUser"
End Code

<h2>User Profile</h2>

<section class="content">
    @Using (Html.BeginForm("FileUpload", "Home", FormMethod.Post, htmlAttributes:=New With {.enctype = "multipart/form-data"}))
        @<div class="row">
            <div class="col-md-12">

                <!-- Profile Image -->
                <div class="box box-primary">
                    <div class="box-body box-profile">
                        <img class="profile-user-img img-responsive img-circle" src="@Url.Action("Profile", "Image")/@ViewBag.pic" onerror="this.src='@Url.Action("dist", "Content")/img/giphy.gif'" width="300" height="300" alt="User profile picture">

                        <h3 class="profile-username text-center">@ViewBag.user</h3>

                        <label for="file">Upload Image:</label>
                        <input type="file" name="file" id="file" style="width: 100%;" />
                        <input type="submit" value="Upload" class="submit" />
                    </div>
                    <!-- /.box-body -->
                </div>

            </div>
        </div>
    End Using
    <!-- /.row -->

</section>
