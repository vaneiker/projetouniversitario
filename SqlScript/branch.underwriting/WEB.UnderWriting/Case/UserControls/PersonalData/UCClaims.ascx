<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCClaims.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PersonalData.UCClaims" %>
<ul class="secundario" style="display: block;">
    <li class="pd_claims">
        <div class="label mT0 mB">
            <strong>claims:</strong>
        </div>
        <div class=" wd100 mB fl">
            <div class="fl wd32 mR-2-p">
                <label class="label">
                    Date Of Death:</label>
                <asp:TextBox ID="DateOfDeathTxt" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="fl wd32 mR-2-p">
                <label class="label">
                    Date Notified:</label>
                <asp:TextBox ID="DateNotifiedTxt" runat="server"  ReadOnly="true"></asp:TextBox>
            </div>
            <div class="fl wd32">
                <label class="label">
                    Cause Of Death:</label>
                <asp:TextBox ID="CauseOfDeathTxt"  runat="server"  ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <div class=" wd100 mB fl">
            <div class=" fl wd32 mR-2-p">
                <label class="label">
                    Date Complete:</label>
                <asp:TextBox ID="DateCompleteTxt" runat="server"  ReadOnly="true"></asp:TextBox>
            </div>
            <div class=" fl wd66">
                <label class="label">
                    Remarks:</label>
                <asp:TextBox ID="RemarksTxt" runat="server" TextMode="MultiLine"  ReadOnly="true"></asp:TextBox>
            </div>
        </div>
    </li>
</ul>
