﻿<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Themes/RockCMS/Layouts/Site.Master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="RockWeb.Themes.RockCMS.Layouts.Default" %>

<asp:Content ID="ctMain" ContentPlaceHolderID="main" runat="server">
    <header class="topbar topbar-inner">
		<section class="container">
			<div class="row">
				<div class="three columns">
					<a href="/rock" class="logo">Home</a>

				</div>
				<div class="five columns offset-by-four content">

					<asp:PlaceHolder ID="phHeader" runat="server"></asp:PlaceHolder>

					<div class="filter-search">
						<input id="search-words">
						<div class="filter">People</div>
					</div>

				</div>
				
				
			</div>
			<div class="row">
				<nav class="twelve columns">
					<asp:PlaceHolder ID="Menu" runat="server"></asp:PlaceHolder>

					<a href="" id="header-lock">Lock</a>
				</nav>
			</div>
		</section>
	</header>            
    
    <div id="content">        
        <section id="page-title">
		    <div class="row">	
			    <h1>Jon Edmiston</h1>

		    </div>
	    </section>

	    <section class="row container">     
  
            <asp:PlaceHolder ID="ContentLeft" runat="server"></asp:PlaceHolder>                        
            <asp:PlaceHolder ID="ContentRight" runat="server"></asp:PlaceHolder>                        
            <asp:PlaceHolder ID="Content" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="UpperBand" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="LowerBand" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="LowerContentLeft" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="LowerContentRight" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="LowerContent" runat="server"></asp:PlaceHolder>           
            <p>test this</p>
             <p>test this</p>
              <p>test this</p>
               <p>test this</p>
                <p>test this</p>
                 <p>test this</p>
                  <p>test this</p>
                   <p>test this</p>
                    <p>test this</p>
                     <p>test this</p>
        </section>
	</div>

	<footer>
		<div class="row">
		    <asp:PlaceHolder ID="Footer" runat="server"></asp:PlaceHolder>
		</div>
	</footer>        

    <script>
        /* script to manage header lock */
        $(document).ready(function () {
            var headerIsLocked = localStorage.getItem("rock-header-lock");

            if (headerIsLocked == "false") {
                $('#header-lock').toggleClass('unlock');
                $('header.topbar').toggleClass('unlock');
                $('#content').toggleClass('unlock');
            }
        });

        $('#header-lock').click(function () {
            $('#header-lock').toggleClass('unlock');
            $('header.topbar').toggleClass('unlock');
            $('body > section.content').toggleClass('unlock');

            if ($('#header-lock').hasClass('unlock')) {
                localStorage.setItem('rock-header-lock', 'false');
            }
            else {
                localStorage.setItem('rock-header-lock', 'true');
            }

            e.preventDefault();
        });
	</script>
            
</asp:Content>

