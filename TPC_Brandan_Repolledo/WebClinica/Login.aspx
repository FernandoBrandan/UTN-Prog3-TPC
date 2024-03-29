﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebClinica.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/Login.css" rel="stylesheet" />
    <script src="js/Login.js"></script>
    <title></title>
</head>
<body>
    <form runat="server">
        <div class="login">
            <div class="login-screen">
                <div class="app-title">
                    <h1>Login</h1>
                </div>
                <div class="login-form">
                    <div class="control-group">
                        <asp:TextBox type="text" class="login-field" placeholder="Usuario" ID="txtUsuario" runat="server"/>
                        <label class="login-field-icon fui-user" for="login-name"></label>
                    </div>

                    <div class="control-group">
                        <asp:TextBox type="password" class="login-field" placeholder="Contraseña" ID="txtPassword" runat="server"/>
                        <label class="login-field-icon fui-lock" for="login-pass"></label>
                    </div>

                    <asp:Button class="btn btn-primary btn-large btn-block" Text="Iniciar sesión" OnClick="Click_IniciaSesion" runat="server"/>
                    <a class="login-link" href="#">¿Olvidaste tu contraseña?</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
