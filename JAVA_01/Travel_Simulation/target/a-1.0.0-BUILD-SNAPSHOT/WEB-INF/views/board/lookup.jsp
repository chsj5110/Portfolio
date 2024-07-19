<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="sec"
    uri="http://www.springframework.org/security/tags"%>
<!DOCTYPE html>

<head>
<style>
  *{margin:0;padding:0;}
  ul,li{list-style:none;}
  .slide{width:100%;height:500px;overflow:hidden;position:relative;text-align:center;}
  .slide ul{width:calc(100% * 4);display:flex;transition:1s;}
  .slide li{width:calc(100% / 4);height:500px;}
  .slide li:nth-child(1){background:#ffa;}
  .slide li:nth-child(2){background:#faa;}
  .slide li:nth-child(3){background:#afa;}
  .slide li:nth-child(4){background:#aaf;}
  .slide input{/*display:none;*/}
  .slide .bullet{position:absolute;bottom:-23px;left:0;right:0;text-align:center;z-index:10;}
  .slide .bullet label{width:50px;height:20px;border-radius:10px;border:2px solid #666;display:inline-block;background:#fff;font-size:10px;transition:0.5s;cursor:pointer;}
  /* 슬라이드 조작 */
  #pos1:checked ~ ul{margin-left:0;}
  #pos2:checked ~ ul{margin-left:-100%;}
  #pos3:checked ~ ul{margin-left:-200%;}
  #pos4:checked ~ ul{margin-left:-300%;}
  /* bullet 조작 */
  #pos1:checked ~ .bullet label:nth-child(1),
  #pos2:checked ~ .bullet label:nth-child(2),
  #pos3:checked ~ .bullet label:nth-child(3),
  #pos4:checked ~ .bullet label:nth-child(4){background:#666;}

/*구글맵*/

	.map {
		
        z-index : 4;
        position : relative;
      }
	
	html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }
     
      #description {
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
      }

      #infowindow-content .title {
        font-weight: bold;
        text-align : center;
      }

      #infowindow-content {
        display: none;
        text-align : center;
      }

      #map #infowindow-content {
        display: inline;
        text-align : center;
      }

      .pac-card {
        margin: 10px 10px 0 0;
        border-radius: 2px 0 0 2px;
        box-sizing: border-box;
        -moz-box-sizing: border-box;
        outline: none;
        box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
        background-color: #fff;
        font-family: Roboto;
      }

      #pac-container {
        padding-bottom: 12px;
        margin-right: 12px;
      }

      .pac-controls {
        display: inline-block;
        padding: 5px 11px;
      }

      .pac-controls label {
        font-family: Roboto;
        font-size: 13px;
        font-weight: 300;
      }

      #pac-input {
      	position : relative;
        background-color: #fff;
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
        margin-left: 12px;
        padding: 0 11px 0 13px;
        text-overflow: ellipsis;
        width: 380px;
        height : 30px;
      }

      #pac-input:focus {
        border-color: #4d90fe;
      }

      #title {
      	border-bottom: 1px solid #999;
        font-size: 25px;
        font-weight: 500;
        padding: 6px 12px;
      }
      #target {
        width: 345px;
      }
      
      #floating-panel {
        position: relative;
    	width: 100px;
    	height: 54px;
    	top: -15px;
    	left: 72%;
        z-index: 5;
        background-color: #fff;
        padding: 5px;
        border: 1px solid #999;
        text-align: center;
        font-family: 'Roboto','sans-serif';
        line-height: 22px;
        padding-left: 10px;
      }
      
      #right-panel {
        font-family: 'Roboto','sans-serif';
        line-height: 30px;
        padding-left: 10px;
        position : relative;
      }

      #right-panel select, #right-panel input {
        font-size: 15px;
      }

      #right-panel select {
        width: 100%;
      }

      #right-panel i {
        font-size: 10px;
      }
      #right-panel {
        height: 100%;
        float: right;
        overflow: auto;
        width : 40%;
      }

  
</style>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<meta name="description" content="">
<meta name="author" content="">

<title>Heroic Features - Start Bootstrap Template</title>

 <!-- Navigation -->


  <!-- Page Content -->
  <div class="container">
    <header class="jumbotron my-4">
 		<div id="aaa">
    			<h2 style="padding-top: 20px;"> 게시글</h2>
    	</div>
    	</header> 
    	<div id="slideDiv" class="slide" style="height:500px;">
    		
  		</div>
  		<div align ="right">
			<div id="rbBtnBox" style="display:none; float:left;">
				<button class="btn deleteRB">게시글 삭제</button>
			</div>
  		
  			<input type="text" id="inputRouteNick" style="float:right;" placeholder="북마크 제목" >
			<button type="button" class="btn btn-primary" id="BookmarkRouteBtn" >경로 북마크하기</button>
    	<br><br>
  		</div>
  		

    	


    		<!-- Page Features -->
   			<div class="form-group">
           		<label>번호</label>
           		<font class="text-gray-900" id="reviewSeq"></font>
           		<div class="form-group" style="float: right;">
           			<label>작성자</label>
           			<font class="text-gray-900" id="reviewWriter"></font>
				</div>
           	</div>
           <div id="tag_div">
		</div> 	
  	
		<div id="review_div">
		</div>
		
	
		
		
		<!-- 댓글 -->
		<h5  style="margin-top:20px;">댓글</h5>
		<div>
			<table>
				<tr>
					<th style='width:100px;'>작성자</th>
					<th style='width:160px;'>내용</th>
					<th>작성일</th>
					<th>비고</th>
				</tr>
				<tbody  class="commentText">
				</tbody>
			</table>
		</div>
		
		<sec:authorize access="hasAnyRole('ROLE_MEMBER','ROLE_ADMIN')">	
			<div style="overflow:auto;display: flex;">
				<div contenteditable="true" class="co_content" style="width:80%; min-height:50px; border:1px solid black; float:left" placeholder="내용을 입력해 주세요."></div>
				<div id="commentBtnRB" class="btn btn-toggle" style="display: flex; align-items: center; justify-content: center; border:1px solid black;">완료</div>
			</div>
		</sec:authorize>
			
			<!-- 게시글 수정 버튼+목록으로 돌아가기 버튼 -->
		<div>	
			<button class="btn btnToRB">돌아가기</button>
		</div>
	
		<div>
			<a href="board_main.do">목록</a> 
		</div>
    </div>


 <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBM3YAiv6ptli8_XfGpVyb6Koy0Ivjxl2Q&libraries=places&region=kr"
         ></script>
<script type="text/javascript">
var user_id=null;
var isAdmin=null;
var seq;

//----------map
var maps = [];
    var markers = [];
	var waypts = [];
	var wpts = [];
	var place, places, map, infowindow, myLatLng, markers_mk, marker1, wp;
	var mylat, mylng, curlat, curlng, currentpos;
	var directionsRenderer = new google.maps.DirectionsRenderer;
	var directionsService = new google.maps.DirectionsService;
	var infowindow = new google.maps.InfoWindow;
	var infowindow1 = new google.maps.InfoWindow;
	var infowindow2 = new google.maps.InfoWindow;
	var infowindow3 = new google.maps.InfoWindow;
	var mapname;
	var arr = [];
	var TravelDays;
	var ttrday=1;

//-----------

$("#BookmarkRouteBtn").on("click", function(){
    		console.log("ttrday:" + ttrday);
    		
    		json={};
    		json.rbseq=seq;
    		json.trday = ttrday;
    		
    		var data = getAjax("/board/selectRouteTR.json", json);
    		
    		json={};
			json.mid = "${userId}";
			console.log(json.mid);
			var dataa = getAjax("/board/selectbookmarkseq.json", json);
			
			console.log(dataa.list[0].NEXTVAL);
			
			json.bmrtseq= dataa.list[0].NEXTVAL;
			var Nick = $("#inputRouteNick").val();
			
			if(Nick==""){
				json.bmnick="";
			}else{
				json.bmnick = $("#inputRouteNick").val();
			}
			
			
			for(var m=0; m<data.list.length; m++){
		    	if(data.list[m].RT_WAYPO_LAT != undefined && data.list[m].RT_WAYPO_LNG != undefined){
		    		
		    		console.log("경유위치 lat, lng");															
		            console.log(data.list[m].RT_WAYPO_LAT +","+data.list[m].RT_WAYPO_LNG);
		            
		            var wp = new google.maps.LatLng(data.list[m].RT_WAYPO_LAT, data.list[m].RT_WAYPO_LNG);

		      		waypts.push({
		                  location: wp,
		                  stopover: true
		                });
		    	}else{
		    		waypts=[];
		    	}
		  	
		    }
			
			json.bmdeplat = data.list[0].RT_DEP_LAT;
			json.bmdeplng = data.list[0].RT_DEP_LNG;
			json.bmarrlat = data.list[0].RT_ARR_LAT;
			json.bmarrlng = data.list[0].RT_ARR_LNG;
			
			if(waypts.length>0){
				
				for(var j=0;j<waypts.length;j++){
					
					console.log(waypts[j].location.lat() + ","+waypts[j].location.lng());
					
		      		json.bmwaypolat = waypts[j].location.lat();
					json.bmwaypolng = waypts[j].location.lng();
					var data = getAjax("/board/insertBookmark.json", json);	
		        }
			}else{
				json.bmdeplat = data.list[0].RT_DEP_LAT;
				json.bmdeplng = data.list[0].RT_DEP_LNG;
				json.bmarrlat = data.list[0].RT_ARR_LAT;
				json.bmarrlng = data.list[0].RT_ARR_LNG;
				
				json.bmwaypolat = "";
				json.bmwaypolng = "";
				var data = getAjax("/board/insertBookmark.json", json);	
			}
			
		   
			
			if(data.addBookmark == true){
				alert("북마크 저장이 성공적으로 완료되었습니다.");
				location.href = "./lookup.do?seq="+seq;
			}else{
				alert("경로 저장에 실패하였습니다.");
				return;
			}
		

    	    
    	    

    		
    	});


function load00(l){
	console.log(TravelDays);

		var trday = l+1;
		console.log("여행 며칠째 : " + trday);
		
		var directionsRenderer = new google.maps.DirectionsRenderer;
		var directionsService = new google.maps.DirectionsService;
		var infoWindow = new google.maps.InfoWindow;
		directionsRenderer.setMap(arr[l]);
		console.log(arr[l]);
		var waypts=[];
		
		json={};
	  	json.rbseq = seq;
	  	json.trday = trday;
		
	  	var data = getAjax("/board/selectRouteTR.json", json);
		
	  	console.log("출발위치 lat, lng");															
	    console.log(data.list[0].RT_DEP_LAT +","+data.list[0].RT_DEP_LNG);
	    var DepartPosition = new google.maps.LatLng(data.list[0].RT_DEP_LAT, data.list[0].RT_DEP_LNG);
	    
	    
	    for(var m=0; m<data.list.length; m++){
	    	if(data.list[m].RT_WAYPO_LAT != undefined && data.list[m].RT_WAYPO_LNG != undefined){
	    		
	    		console.log("경유위치 lat, lng");															
	            console.log(data.list[m].RT_WAYPO_LAT +","+data.list[m].RT_WAYPO_LNG);
	            
	            var wp = new google.maps.LatLng(data.list[m].RT_WAYPO_LAT, data.list[m].RT_WAYPO_LNG);

	      		waypts.push({
	                  location: wp,
	                  stopover: true
	                });
	    	}else{
	    		waypts=[];
	    	}
	  	
	    }
	    console.log("도착위치 lat, lng");
	    console.log(data.list[0].RT_ARR_LAT +","+data.list[0].RT_ARR_LNG);
	    var ArrivePosition = new google.maps.LatLng(data.list[0].RT_ARR_LAT, data.list[0].RT_ARR_LNG);

	    var selectedMode = 'DRIVING' ;
	    
	    
	    directionsService.route({
	      origin: DepartPosition , 															// 현재위치를 출발점으로 설정
	      destination: ArrivePosition,
	      waypoints: waypts,
	      travelMode: google.maps.TravelMode[selectedMode]
	    }, function(response, status) {
	      if (status == 'OK') {
	        directionsRenderer.setDirections(response);
	      } else {
	        window.alert('Directions request failed due to ' + status);
	      }
	    });
	  
	    console.log("================for m end===========================");
}



$(document).ready(function(){	
	
	

		
	user_id="${userId}"
	seq = ${seq};
	
	//-----------------
	json={};
  	json.rbseq = ${seq};
  	
  	var data = getAjax("/board/getMaxTrday.json", json);
  	
  	console.log("data = " + data.data);
  	console.log("list = " + data.list.length);
  	
	if(data.list.length > 0) {
  	
	  	TravelDays = data.list[0].TR_DAY;
		console.log(TravelDays);
	  	
	  	html="";
	  	html += " <input type='radio' name='pos' id='pos1' checked>";
	  	
	  	for(var j=2; j<=TravelDays; j++){
	  		
	  		html += "&emsp;" +" <input type='radio' name='pos' id='pos" +j+ "'>";
	  	}
	  	
			html += "<ul style='height: 500px;'>";
			html += "<li style='height: 500px;'>";
			html += "<div class='map' id='map1' style='height:500px; width:100%'></div></li>";
			
		for(var k=2; k<=TravelDays; k++){
			html += "<li style='height: 500px;'>";
			html += "<div class='map' id='map"+k+"' style='height:500px; width:100%'></div>";
			html += "</li>";
		}
	
		html += "</ul>";
		html += "<p class='bullet'>";
		html += "<label for='pos1'>1일차</label>";
		
		for(var m=2; m<=TravelDays; m++){
			html += "<label for='pos"+m+"'>"+m+"일차</label>";
		}
		html+= "</p>";
		$("#slideDiv").html(html);	
		
		console.log("slideload..");
		//-----------------
		
		isAdmin=${isAdmin}
	
		console.log(isAdmin);
	}
	
		//-----------
	var $maps = $('.map');
	        
	    $.each($maps, function (i, value) {
		            
	
	        var mapDivId = $(value).attr('id');
	
	        maps[mapDivId] = new google.maps.Map(document.getElementById(mapDivId), {
	            zoom: 15,
	            center: {lat: 35.1379222, lng:129.05562775}
	        });
	
	            
	        arr.push(maps[mapDivId]);
	    })
	        
		console.log("arrrrrrrrrrrrrrr");
	    console.log(arr);
	        
	    if(data.list.length > 0) {
	        
		    for(var l=0; l<TravelDays; l++){
		       	load00(l);
		       	console.log("load00..");
		    }
	    }
	    $("input:radio[name='pos']").change(function(){
	    	var checked= $("input:radio[name='pos']:checked").attr('id');
	    	console.log(checked);
	    	ttrday = checked.substring(3);
	    	console.log(ttrday);
	    		
	    });
	        
	    json={};
	    json.rbseq=seq;
	    //해시태그
	    var dataa = getAjax("/board/gettag.json", json)	//ajax
	    	
	    html="";
	    for (var k = 0; k < dataa.list.length; k++) {		
	    	var urltag = encodeURI(dataa.list[k].TAGNAME, 'UTF-8');
      		html += "<a class='card-text' href='/board_tag.do?tagname="+urltag+"' style='color : black;'> #" + dataa.list[k].TAGNAME + "</a>";
	    }
	    $("#tag_div").html(html);
		
        
	//-------------
	
	
	alert("seq=="+seq);
	$("#reviewSeq").append(seq);
	
	
	
	
	
	json = {};
	json.seq = "${seq}";
	console.log("seq : "+ json.seq);
	var data = getAjax("/board/lookup.json",json);
		console.log("data = " + data.Review[0].URV_PLACE);
		console.log("data1 : "+ data.reviewlistCnt);
		console.log("data2 : "+ data.Review);
		datareviewlist = data.reviewlistCnt;
		Reviewdata = data.Review;
		console.log("data ======================" + data);
		console.log("datareviewlist =="+datareviewlist);
		console.log("Reviewdata =="+Reviewdata);
		
		$("#reviewWriter").append(data.Review[0].M_ID);
	var html="";
	for(var i = 0; i < datareviewlist; i++){ 
		html +="<div id='review_div"+i+"' style='overflow:hidden;height:auto;'>";
		html +=	 "<div id='review_img' style=''>";
		html +=		"<div id='view_img' style='float: left; margin-right: 10px;'>";
		html +=			"<img src='/img/"+Reviewdata[i].URV_IMG+"' style='height: 150px; width: 150px;'/>";
		html +=		"</div>";
		html +=		"<div id='review"+i+"' style='float: left;width: 75%;'>";
		html +=       "<div id='bb'>";
		html +=       "<label style='display: none;'>리뷰 번호"+Reviewdata[i].REVIEWBNO+"</label>";
		html +=    "<div id='placename"+i+"' style='float:right;border-left:1px solid #BDBDBD;padding-left:5px;'>"+data.Review[i].URV_PLACE+"</div>"
	 	html +=       "<div class='form-group'>";
	 	html +=       	"<h4 id='title'>"+Reviewdata[i].URV_TITLE+"</h4>";
	 	html +=       "</div>";
	 	html +=       "<div class='form-group'>";
	 	html +=       	"<p id='Content'>"+Reviewdata[i].URV_CONTENT+"</p>";
	 	html +=       "</div>";	
			 	
		if(user_id==Reviewdata[0].M_ID || isAdmin==true){
			html +=		  "<button type:'button' id='modifybtn"+i+"' class='btn btn-primary' onclick='modifybtn("+i+")'>수정</button>";
		}
			
	 	html +=       "</div>"; 
		html +=		"</div>";
		html +=		"<div id='text_div"+i+"'style='float: left;width: 75%;'>";
		html +=			"<div id='aa"+i+"'>";
		html +=		"</div>";
		
		html +=	 "</div>";
		
		
		html +=	"</div>";
		

		html +="</div>";
		html +="<div id='star"+i+"' name='starDiv' class='starRev' style='margin-bottom:5vw;' >";
		for(j=0; j<5; j++) {
			html +="<span class='starR1' name='starR'>별1_왼쪽</span>";
			html +="<span class='starR2' name='starR'>별1_오른쪽</span>";
		}
		html +="<h4 id='grade"+i+"' style='margin-left:2px;width:150px;'></h4>";
		html +="</div>";
	}
	if(user_id==Reviewdata[0].M_ID || isAdmin==true){
		$("#rbBtnBox").show();
	}
	$("#review_div").append(html);	
	//댓글 목록 출력
	commentListFB(seq,user_id);
	


	
	
	
	//게시글 삭제
	$(".deleteRB").on("click", function(){
		if (confirm("정말로 삭제하시겠습니까?")){
			dataInfo=null;
			dataInfo=getAjax("./deleteRB.json",json);

			if (dataInfo.success=="Y"){
				alert("게시글이 삭제되었습니다.")
				location.href="./board_main.do";
			} else {
				alert("게시글이 삭제되지 못했습니다.");
			}
		}
	});		
	
	
	//게시글 목록으로 돌아가기
	$(".btnToRB").on("click", function(){
		location.href="./board_main.do";		
	});	
	
	//댓글입력
	$("#commentBtnRB").on("click", function(){
		var cJson={};
		cJson.rb_seq=seq;
		cJson.content=$(".co_content").html();	
		cJson.date = nowDate();
					
		var data=null;
		data=getAjax("./insertCommentRB.json",cJson);
		if(data.success=="Y"){
			alert("댓글이 성공적으로 작성되었습니다");
			$(".co_content").empty();
			commentListFB(seq,user_id);
		} else{
			alert("오류가 발생했습니다.")
		}		
	});
	grades(i);
	
});	


//평점 가져오기
function grades(i) {
	json = {};
	json.PLACE = $("#placename"+i+"").html();
	json.ID = $("#reviewWriter").html();
	console.log("jsno ==========="+json);
	data = getAjax("/tripList.json", json);
	for(j=0; j<data.data.length; j++) {
		console.log(data.data[j]);
		for(z=0; z<data.data.length; z++) {
			if($("#placename"+j+"").html() == data.data[z].PLACE) {
				var grade = parseFloat(data.data[j].GRADE)*2;
				for(k=0; k<grade; k++) {
					$("#star"+j+" span").eq(k).addClass( 'on' );
					$("#grade"+j+"").text(($("#star"+j+" span[class='starR2 on']").length + $("#star"+j+" span[class='starR1 on']").length)/2);
				}
			}
		}
	}
}


//리뷰 수정
function modifybtn(i){
	$("#aa"+i+"").html("");
	$("#review"+i).hide();
	$("#modifybtn"+i).hide();
	var html =  "";
		html += "<div class='form-group' style='margin-bottom: 0px;'>";
		html +=	"<label style=''>번호</label>";
		html += "<font class='text-gray-900' id='modifySeq"+i+"' style='''> </font>";
		html += "</div>";
		html += "<div class='form-group' style='margin-bottom: 0px;'>";
		html += "<label>제목</label>";
		html += "<input class='form-control' id='modifyTitle"+i+"'></input>";
		html += "</div>";
		html += "<div class='form-group'>";
		html += "<label>내용</label>";
		html += "<textarea style='resize: none; height: 62px;' class='form-control' id='modifyContent"+i+"'></textarea>";
		html += "</div>";
		html += "<button type='button' id='modifyconfirmbtn"+i+"'>완료</button>";
		html += "<button type='button' id='closebtn"+i+"' onclick='closebtn("+i+")'>취소</button>";
	$("#aa"+i+"").append(html);
	alert("수정 시퀀스 ="+Reviewdata[i].REVIEWBNO);
	
	
	
	json.modifyBno = Reviewdata[i].REVIEWBNO;
	console.log(json.modifyBno);
	var data = getAjax("/board/modifybno.json",json);
		modifydata = data.modifydata;
		console.log(modifydata.REVIEWBNO);
		console.log(modifydata.URV_TITLE);
		console.log(modifydata.URV_CONTENT);
	$("#modifySeq"+i+"").append(modifydata.REVIEWBNO);
	$("#modifyTitle"+i+"").val(modifydata.URV_TITLE);
	$("#modifyContent"+i+"").val(modifydata.URV_CONTENT);
	
	$("#modifyconfirmbtn"+i+"").on("click",function(){
		json.modifySeq     = $("#modifySeq"+i+"").text();
		json.modifyTitle   = $("#modifyTitle"+i+"").val();	
		json.modifyContent = $("#modifyContent"+i+"").val();
		reviewSeq = json.modifySeq;
		Title 	  = json.modifyTitle;
		Content   = json.modifyContent;
		var data = getAjax("/board/modify.json",json);
			alert(json.modifySeq+"수정됨 ");
			
		confirmhtml(i);
		
		$("#boardSeq"+i+"").append(reviewSeq);
  		$("#Title"+i+"").append(Title);
		$("#Content"+i+"").append(Content);		
	});
}

//수정완료
function confirmhtml(i){
	 $("#aa"+i+"").remove();
	var html="";
		html += "<div id='aa"+i+"'>";
		html +=	"<label style=''>번호 </label>";
		html += "<font class='text-gray-900' id='boardSeq"+i+"' style='''> </font>";
		html += "<div class='form-group'>";
		html += 	"<h4 id='Title"+i+"'></h4>";
		html += "</div>";
		html += "<div class='form-group'>";
		html += 	"<p id='Content"+i+"'></p>";
		html += "</div>";
		html += "<button type:'button' id='modifybtn"+i+"' onclick='modifybtn("+i+")'>수정</button>"	
		html += "</div>"; 
		
		$("#text_div"+i+"").append(html);
	} 

//닫기 버튼
function closebtn(i){
	$("#aa"+i+"").html("");
	$("#reviewtextbtn"+i+"").show();
}


function commentListFB(seq,user_id){	
	var jsonL={};
	jsonL.seq=seq;
	
	var data={};
	data=getAjax("/commentListRB.json",jsonL).list;
	
	console.log(data);
	
	$(".commentText").empty();
	
	var html = "";
	for(i=0; i<data.length; i++){
		html += "<tr><td>"+data[i].M_ID;
		html +="</td><td>"+data[i].C_CONTENT;
		html +="</td><td>"+data[i].C_CREATEDATE+"</td>";		
		

		
		if(data[i].M_ID==user_id || user_id=="ROLE_ADMIN"){
			html +="<td><button class='commentDelete' value='"+data[i].C_SEQ+"'>삭제</button></td>";
		}
		html +="</tr>";
		
	}			
	$(".commentText").html(html);	
	
	//댓글 삭제
	$(".commentDelete").on("click", function(){
		var jsonD={};
		jsonD.seq=$(this).attr('value');
		jsonD.fb_seq=seq;

		var data={};
		data=getAjax("/deleteComment.json",jsonD);
		if(data.success=="Y"){
			alert("댓글이 삭제되었습니다.");
			commentListFB(seq,user_id);
		} else{
			alert("댓글이 삭제되지 않았습니다.");
		}
	});
}




//-------------map
function slideload(){
	
	json={};
  	json.rbseq = seq;
  	
  	var data = getAjax("/board/selectRouteTR.json", json);
	
  	for(var i=0; i<data.list.length;i++){
  		var TravelDays;
  		TravelDays = data.list[i].TR_DAY;
  	}
  	
  	html="";
  	
  	for(var j=0; j<TravelDays; j++){
  		
  		html += " <input type='radio' name='pos' id='pos"+j+"' checked> ";
  	}
  	
		html += "<ul style='height: 500px;'>";
		html += "<li style='height: 500px;'>";
		html +=	"<div id='floating-panel'> <b>이동 수단:</b> <select id='mode'>";
		html += "<option value='DRIVING'>Driving</option>"
					+ "<option value='WALKING'>Walking</option>" 
		 			+ "<option value='BICYCLING'>Bicycling</option>"
					+ "<option value='TRANSIT'>Transit</option>";
		html += "</select></div><div id='right-panel' >";	
			
	
  	
	
  	
  	
}

function load(){
	var infoWindow = new google.maps.InfoWindow;
	

  	directionsRenderer.setMap(map);
  	directionsRenderer.setPanel(document.getElementById('navigator'));
  	
  	if (navigator.geolocation) {
    	navigator.geolocation.getCurrentPosition(function(position) {
    		var pos = {
          		//lat: position.coords.latitude,
          		//lng: position.coords.longitude
          		lat: 51.047141,
          		lng: -114.058744								// 실제 사용시 정확한 현재위치 표시를 위해 주석처리 된 부분 풀어야함
    		};

        	infoWindow.setPosition(pos);
        	infoWindow.setContent('Location found.');
        	map.setCenter(pos);
        
        	//curlat = position.coords.latitude;				// 현재위치 받아오는 소스
        	//curlng = position.coords.longitude;
        	
        	curlat = 51.047141;									// 주석 풀때 이부분을 주석처리 or 지울것
        	curlng = -114.058744;
        
        	marker1 = new google.maps.Marker({
            	map: map,
            	position: new google.maps.LatLng(curlat, curlng)
          	});
      	}, function() {
        		handleLocationError(true, infoWindow, map.getCenter());
      		}); //end navigator.geolocation
    } else {
      // Browser doesn't support Geolocation
      handleLocationError(false, infoWindow, map.getCenter());
    }
  
  /////-----------------------------현재위치 받는 부분
  
  
  	// Create the search box and link it to the UI element.
  	//input = document.getElementById('pac-input');
  	rtpn = document.getElementById('floating-panel');
  	searchBox = new google.maps.places.SearchBox(input);
  	//map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
  	map.controls[google.maps.ControlPosition.TOP_LEFT].push(rtpn);

  	console.log("seq:"+seq);
  	json={};
  	json.rbseq = seq;
  	
  	var data = getAjax("/board/selectRouteTR.json", json);
  	
  	console.log("----------------------------------------------------");
	console.log("---------call Route Button Click Console.log---------");
	console.log("----------------------------------------------------");
	
	
    console.log("출발위치 lat, lng");															
    console.log(data.list[0].RT_DEP_LAT +","+data.list[0].RT_DEP_LNG);
    DepartPosition = new google.maps.LatLng(data.list[0].RT_DEP_LAT, data.list[0].RT_DEP_LNG);
    
    
    for(var i=0; i<data.list.length;i++){
    	if(data.list[i].RT_WAYPO_LAT != undefined && data.list[i].RT_WAYPO_LNG != undefined){
    		
    		console.log("경유위치 lat, lng");															
            console.log(data.list[i].RT_WAYPO_LAT +","+data.list[i].RT_WAYPO_LNG);
            
            wp = new google.maps.LatLng(data.list[i].RT_WAYPO_LAT, data.list[i].RT_WAYPO_LNG);

      		waypts.push({
                  location: wp,
                  stopover: true
                });
    	}else{
    		waypts=[];
    	}
  	
    }
    
    ArrivePosition = new google.maps.LatLng(data.list[0].RT_ARR_LAT, data.list[0].RT_ARR_LNG);
    
  	calculateAndDisplayRoute(directionsService, directionsRenderer)
  
}
    
    

function calculateAndDisplayRoute(directionsService, directionsRenderer) {
	  
	  
	
	
	
	
    var selectedMode = document.getElementById('mode').value;
    
    
      directionsService.route({
        origin: DepartPosition , 															// 현재위치를 출발점으로 설정
        destination: ArrivePosition,
        waypoints: waypts,
        travelMode: google.maps.TravelMode[selectedMode]
      }, function(response, status) {
        if (status == 'OK') {
          directionsRenderer.setDirections(response);
        } else {
          window.alert('Directions request failed due to ' + status);
        }
      });
    
      $('#pac-input').val("");
      searchBox = new google.maps.places.SearchBox(input);
      $('#pac-input').attr("placeholder", "Search Box");
    
    //----------------------------------------- infoWindow소스

    

    
    contentStart = "<div style='text-align : center;'><p>출발지</p></div>";
    contentEnd = "<div style='text-align : center;'><p>도착지</p></div>";
  	contentWP = "<div style='text-align : center;'><p>경유지</p></div>";
  	
  	infowindow1 = new google.maps.InfoWindow({
  			content: contentStart,
      		maxWidth: 200,
      		position : DepartPosition
  		});
  	infowindow1.open(map);
		
		infowindow2 = new google.maps.InfoWindow({
			content: contentEnd,
  		maxWidth: 200,
  		position: ArrivePosition
		});
		infowindow2.open(map);
	infowindow3=[];
	 for(i=0;i<waypts.length;i++){
		 
		 wpts = new google.maps.LatLng(waypts[i].location.lat(), waypts[i].location.lng());
		 infowindow3[i] = new google.maps.InfoWindow({
	  			content: contentWP,
	      		maxWidth: 200,
	      		position : wpts
	  		});
		 infowindow3[i].open(map);
     }

	
	//---------------------------------------- console.log 소스
	
      console.log("현재위치 lat, lng");														
      console.log(curlat+","+curlng);
      console.log("출발위치 lat, lng");															
      console.log(DepartPosition.lat() +","+DepartPosition.lng());
      
      for(var i=0;i<waypts.length;i++){
    	  console.log("경유지 위치 lat, lng");
    	  console.log(waypts[i].location.lat() + ","+waypts[i].location.lng());
      }
      console.log("목표위치 lat, lng");
      console.log(ArrivePosition.lat() +","+ ArrivePosition.lng());
      console.log("----------------------------------------------------");

}   


</script>

