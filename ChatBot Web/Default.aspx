<%@ Page
	Language           = "C#"
	AutoEventWireup    = "false"
	Inherits           = "ChatBot_Web.Default"
	ValidateRequest    = "false"
	EnableSessionState = "false"
%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>ChatBot Web</title>

		<meta http-equiv="content-type" content="text/html; charset=utf-8" />
		<meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
		<meta http-equiv="PRAGMA" content="NO-CACHE" />

		<link href="ChatBot_Web.css" type="text/css" rel="stylesheet" />
		
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
		<!-- Site Code goes here! -->
			<table>

				<tr>
					<td colspan="2">
						Table
					</td>
				</tr>

				<tr>
				<td>
						Name:
					</td>
					<td>
						<input id="_Input_Name" runat="server" />
					</td>
				</tr>

				<tr>
					<td colspan="2">
						<input id="_Button_No" type="submit" value="Oh No!" runat="server" />
						<input id="_Button_Ok" type="submit" value="Ok" runat="server" />
					</td>
				</tr>

				<tr>
					<td colspan="2" align="center">
						<a href="?" >Click Here</a>
					</td>
				</tr>

			</table>

		</form>
	</body>
</html>
