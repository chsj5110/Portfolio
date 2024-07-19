<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
  
<style>
label {
	position: relative;
	top: 6px;
	color: blue;
}
/* .selected {
	background-color:aquamarine;
} */
.t_seq{
    text-align: left;
    color:blue;
}
.t_title{
	text-align: left;	
}
.imgUl {
    list-style:none;
    margin:0;
    padding:0;
    width:100%;
    display:flex;
}

.imgLi {
    margin: 0 3% 0 0;
    padding: 0 0 0 0;
    border : 0;
    float: left;
    width:30%;
}
img {
}
</style>
<script type="text/javascript">
	$(document).ready(function(){
		
		var json = {};
		var data = null;
		
		json.D_NAME = "${seq}";
		data = getAjax("areaInfo.json", json);
		console.log(data.data);
		$("#insertCty").empty();
		$("#insertDname").empty();
// 		헤더
		$("#insertCty").html(data.data[0].CTY_NAME+"("+data.data[0].AREA+")");
		$("#insertDname").html(data.data[0].D_NAME);
		$("#bodyDiv").empty();
		var html="";
// 			바디
			html+="<div class='card shadow mb-4' style='width:150%;'>";
			html+="<div class='card-header py-3' style='display:flex;'>";
			html+= "<ul class='imgUl'>"
			for(i=0; i<data.data.length; i++) {
			    html+= "<li class='imgLi'>"
				html+= "<img class='card-img-top' style='height:100%;' src='"+ data.data[i].URL +"/"+ data.data[i].IMG_UUID +"' alt=''>";
				html+= "</li>"
			}
			html+= "</ul>"
			html+="</div>";
			html+="<div class='card-body'>";
			html+="<div class='table-responsive'>";
			html+="<div style='float:left;'>";
			html+="<div class='t_seq'>소개</div>";
			html+="<div class='t_title'>"+ data.data[0].D_INFO +"</div>";
			html+="</div>";
			html+="</div>";
			html+="</div>";
			html+="</div>";
			
		$("#bodyDiv").html(html);
		
		
		
	})
</script>

<div style="display:none;"><input type="text" id="sJson"></div>
<!-- Main Content -->
<div id="content" style="padding:10px 10%; max-width:70%;">
	<header class="jumbotron my-4" style="width:150%;">
      <h1 class="display-3" id="insertCty"></h1>
      <p class="lead" id="insertDname"></p>
	<!-- <a href="#" class="btn btn-primary btn-lg">Call to action!</a> -->
    </header>
	<!-- Begin Page Content -->
	<div class="container-fluid" id="bodyDiv">
	
	<!-- <img src="./img/gif/chika.gif"> -->

	</div>
	<!-- /.container-fluid -->

</div>
<!-- End of Main Content -->