@ModelType Trust.Ms_Customer_KYC
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>KYC</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Customer_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Customer_Name)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Legal_Domicile_City)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Legal_Domicile_City)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOE_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOE_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOE_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOE_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOE_Notary)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOE_Notary)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOE_Approval_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOE_Approval_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOE_IsUploaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOE_IsUploaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AOA_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AOA_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AOA_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AOA_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AOA_Notary)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AOA_Notary)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AOA_IsUploaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AOA_IsUploaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.BOD_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BOD_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.BOD_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BOD_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.BOD_Notary)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BOD_Notary)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.BOD_Letter_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BOD_Letter_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.BOD_Letter_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BOD_Letter_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.BOD_IsUploaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BOD_IsUploaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA1_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA1_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA1_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA1_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA1_Notary)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA1_Notary)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA1_Regarding)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA1_Regarding)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA1_Letter_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA1_Letter_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA1_Letter_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA1_Letter_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA1_IsUploaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA1_IsUploaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA2_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA2_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA2_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA2_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA2_Notary)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA2_Notary)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA2_Regarding)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA2_Regarding)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA2_Letter_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA2_Letter_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA2_Letter_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA2_Letter_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA2_IsUploaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA2_IsUploaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA3_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA3_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA3_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA3_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA3_Notary)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA3_Notary)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA3_Regarding)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA3_Regarding)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA3_Letter_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA3_Letter_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA3_Letter_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA3_Letter_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA3_IsUploaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA3_IsUploaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA4_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA4_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA4_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA4_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA4_Notary)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA4_Notary)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA4_Regarding)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA4_Regarding)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA4_Letter_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA4_Letter_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA4_Letter_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA4_Letter_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA4_IsUploaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA4_IsUploaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA5_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA5_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA5_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA5_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA5_Notary)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA5_Notary)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA5_Regarding)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA5_Regarding)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA5_Letter_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA5_Letter_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA5_Letter_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA5_Letter_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DOA5_IsUploaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DOA5_IsUploaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Business_License_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Business_License_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Business_License_IssuedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Business_License_IssuedBy)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Business_License_IssuedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Business_License_IssuedDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Business_License_ExpiredDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Business_License_ExpiredDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Business_License_IsUploaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Business_License_IsUploaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TDP)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TDP)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TDP_IssuedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TDP_IssuedBy)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TDP_IssuedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TDP_IssuedDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TDP_ExpiredDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TDP_ExpiredDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TDP_IsUploaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TDP_IsUploaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SKDP_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SKDP_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SKDP_Address)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SKDP_Address)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SKDP_IssuedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SKDP_IssuedBy)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SKDP_IssuedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SKDP_IssuedDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SKDP_IsUploaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SKDP_IsUploaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NPWP_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NPWP_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NPWP_IsUploaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NPWP_IsUploaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Authorized_Person)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Authorized_Person)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Annual_Income)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Annual_Income)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Purpose_of_Services)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Purpose_of_Services)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Identitas)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Identitas)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Identitas_IsUploaded)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Identitas_IsUploaded)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Authorized_Capital)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Authorized_Capital)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Issued_Paidup_Capital)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Issued_Paidup_Capital)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedDate)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedBy)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ModifiedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ModifiedDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ModifiedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ModifiedBy)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
