<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="tiles" uri="http://tiles.apache.org/tags-tiles"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>

<!DOCTYPE html>
<html lang="en">

<head>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">
  
  <!-- ajax 통신을 위한 meta tag -->
  <meta name="_csrf" content="${_csrf.token}">
  <meta name="_csrf_header" content="${_csrf.headerName}">
  
  <title>여행시뮬레이션</title>
  
  <!-- Bootstrap core CSS -->
  <link href="/../../resources/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Custom styles for this template -->
  <link href="/../../resources/css/heroic-features.css" rel="stylesheet">
  
<!--   <link href="/../../resources/css2/_bootswatch.scss" rel="stylesheet">
  <link href="/../../resources/css2/_variables.scss" rel="stylesheet"> -->
  <link href="/../../resources/css2/bootswatch.css" rel="stylesheet">
  <link href="/../../resources/css2/bootstrap.css" rel="stylesheet">
  <link href="/../../resources/css2/bootstrap.min.css" rel="stylesheet">
  
  
  <script src="../../resources/js/common/common.js?ver=1.3" type="text/javascript" charset="utf-8"></script>
  <script src="/../../resources/vendor/jquery/jquery.min.js"></script>
  
  <style type="text/css">
  	.navbar-dark .navbar-nav .nav-link {
	  	color: #333;
		background-color: transparent;
		font-size: 1.1em;
	}
	
	.navbar-dark .navbar-nav .nav-link:hover, .navbar-dark .navbar-nav .nav-link:focus {
		color:  #b7b7b7;
		background-color: transparent;
		font-size: 0.9em;
	}
	
	#locationSerch{
		width: 100%;
		height:56px;
		text-align:center;
		margin-top: 1%;
		margin-bottom: -1%;
	}
	
	.custom-select{
		width: 14%;
	}
	
	.btn-primary{
	    background-color: #7c898e7a;
	}
	
	.btn-primary:hover {
		color: #fff;
		background-color: #8a9a9a;
		border-color: #1a1919;
	}
	
	.btn-primary:focus, .btn-primary.focus {
		color: #fff;
		background-color: #202020;
		border-color: #1a1919;
		-webkit-box-shadow: 0 0 0 0.2rem rgba(82, 82, 82, 0.5);
		box-shadow: 0 0 0 0.2rem rgba(82, 82, 82, 0.5);
	}
	
	.alertInfo{
		padding: 1%;
	}
	
	#map {
		margin-top: 1%;
	}
	
	.text-white{
		color: #484848 !important;
	}
	
 	
		#footerLayout{
		    position: sticky; 
		}
		#bodyLayout {
			min-height: 100vh;
		}
		.bodySide{
			width: 5%;
		}
		.bodyCenter{
			width: 70%;
		}
 	

  </style>
</head>

<body marginheight="0" marginwidth="0" style="margin: 0px; padding: 0px;">
	
	<section id="headerLayout">
			<tiles:insertAttribute name="header" />
  	</section>
  	<div style="height:56px;"></div>
  	<section id="bodyLayout" >
  		<table style="width: 100%;">
			<tr>
				<td class="bodySide">&nbsp;</td>
				<td class="bodyCenter">
					<tiles:insertAttribute name="body" />
				</td>
				<td class="bodySide">&nbsp;</td>
			</tr>
		</table>
	</section>
	<section id="footerLayout" style="bottom: 0; width: 100%;">
		<tiles:insertAttribute name="footer" />
	</section>

</body>

</html>