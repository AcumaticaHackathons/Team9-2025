<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="LS100000.aspx.cs" Inherits="Page_LS100000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="LS.EfficiencyMonitor.MonitorSetupMaint"
        PrimaryView="Form"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Form" Width="100%" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule runat="server" StartRow="True" StartColumn="True"/>
			<px:PXCheckBox ID="AlertBasedOnUserReport" runat="server" DataField="AlertBasedOnUserReport" />
			<px:PXCheckBox ID="AlertBasedOnUtilization" runat="server" DataField="AlertBasedOnUtilization" />

			<px:PXLayoutRule runat="server" StartRow="False" StartColumn="True"/>
			<px:PXNumberEdit ID="nbrUserReportThreshold" runat="server"  DataField="UserReportThreshold" />
			<px:PXNumberEdit ID="CpuThreshold" runat="server"  DataField="CpuThreshold" />

			<px:PXLayoutRule runat="server" StartRow="False" StartColumn="True"/>
			<px:PXNumberEdit ID="UserReportThresholdTime" runat="server"  DataField="UserReportThresholdTime" />
			<px:PXNumberEdit ID="CpuThresholdTime" runat="server"  DataField="CpuThresholdTime" />
			
			<px:PXLayoutRule runat="server" StartRow="True" ControlSize="M"/>
			<px:PXSelector runat="server" ID="slNotificationTemplateID" DataField="NotificationTemplateID"/>
			
		</Template>
		<AutoSize Container="Window" Enabled="True" MinHeight="200" />
	</px:PXFormView>
</asp:Content>

