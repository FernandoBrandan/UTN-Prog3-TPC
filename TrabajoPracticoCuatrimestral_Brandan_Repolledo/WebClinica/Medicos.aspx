﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="WebClinica.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-row">
        <div class="form-group col-md-3">
            <label for="inputEmail4">Email</label>
            <input type="email" class="form-control" id="inputEmail4">
            <label for="inputPassword4">Password</label>
            <input type="password" class="form-control" id="inputPassword4">

            <label for="inputEmail4">Email</label>
            <input type="email" class="form-control" id="inputEmail4">
            <label for="inputPassword4">Password</label>
            <input type="password" class="form-control" id="inputPassword4">
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-3">
            <label for="inputEmail4">Email</label>
            <input type="email" class="form-control" id="inputEmail4">
            <label for="inputPassword4">Password</label>
            <input type="password" class="form-control" id="inputPassword4">

            <label for="inputEmail4">Email</label>
            <input type="email" class="form-control" id="inputEmail4">
            <label for="inputPassword4">Password</label>
            <input type="password" class="form-control" id="inputPassword4">
        </div>
    </div>
    <div class="form-group">
        <label for="inputAddress2">Address 2</label>
        <input type="text" class="form-control" id="inputAddress2" placeholder="Apartment, studio, or floor">
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputCity">City</label>
            <input type="text" class="form-control" id="inputCity">
        </div>
        <div class="form-group col-md-4">
            <label for="inputState">State</label>
            <select id="inputState" class="form-control">
                <option selected>Choose...</option>
                <option>...</option>
            </select>
        </div>
        <div class="form-group col-md-2">
            <label for="inputZip">Zip</label>
            <input type="text" class="form-control" id="inputZip">
        </div>
    </div>
    <div class="form-group">
        <div class="form-check">
            <input class="form-check-input" type="checkbox" id="gridCheck">
            <label class="form-check-label" for="gridCheck">
                Check me out
            </label>
        </div>
    </div>
    <button type="submit" class="btn btn-primary">Sign in</button>


</asp:Content>
