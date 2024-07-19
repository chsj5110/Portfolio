<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    <head>
    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">
  
  <!-- ajax 통신을 위한 meta tag -->
  <meta name="_csrf" content="${_csrf.token}">
  <meta name="_csrf_header" content="${_csrf.headerName}">
  
    <style>
      /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
      #map {
        height: 100%;
      }
      /* Optional: Makes the sample page fill the window. */
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


      #title {
        color: #fff;
        background-color: #4d90fe;
        font-size: 25px;
        font-weight: 500;
        padding: 6px 12px;
      }
      #target {
        width: 345px;
      }
      #floating-panel {
        /*position: absolute;*/
        top: 0px;
        left: 35%;
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
      }

      #right-panel select, #right-panel input {
        font-size: 15px;
      }

      #right-panel select {
        width: 100%;
      }

      #right-panel i {
        font-size: 12px;
      }
      #right-panel {
        height: 100%;
        float: right;
        width: 390px;
        overflow: auto;
      }

    </style>
<div id="right-panel" >
		
			<div id="bookmark"></div>
			<a href ='javascript:doDisplay();' style="color : black; text-decoration:none; text-align : center;">
				<p id="textinput">길찾기 자세히보기(클릭)</p>
			</a>
			<div id="navigator" style="display:none;">
			</div>
		</div>
		
		<div style="height:100% ; width:100%;">
		<div id="map"></div>
  		</div>


</head>    
<script src="http://code.jquery.com/jquery-latest.min.js"></script>
 <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBM3YAiv6ptli8_XfGpVyb6Koy0Ivjxl2Q&libraries=places&region=kr"
         ></script>
 <script src="../../resources/js/common/common.js?ver=1.3" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript">
 
 
 	var map = new google.maps.Map(document.getElementById('map'), {
 		center: {lat: 35.1379222, lng: 129.05562775},
 		zoom: 13,
 		mapTypeId: 'roadmap'
		});
 	var directionsRenderer = new google.maps.DirectionsRenderer;
	var directionsService = new google.maps.DirectionsService; 
	var service = new google.maps.places.PlacesService(map);
	var waypts = [];
	var wpts = [];
	var infowindow = new google.maps.InfoWindow;
	var userId;
	
	
	
	
	
 $(document).ready(function(){
	 directionsRenderer.setMap(map);
	 directionsRenderer.setPanel(document.getElementById('navigator'));
	 function getParam(sname) {
		    var params = location.search.substr(location.search.indexOf("?") + 1);
		    var sval = "";
		    params = params.split("&");
		    for (var i = 0; i < params.length; i++) {
		        temp = params[i].split("=");
		        if ([temp[0]] == sname) { sval = temp[1]; }
		    }
		    return sval;
		}

		userId = getParam("userId");

	 	json={};
	 	json.mid = userId;
	 	console.log("before");
		var data = getAjax("/board/selectBMRoute1.json", json);
		console.log("after");
		
		html="";
		html+= "<br><h3 style='text-align : center;'>"+userId+"님의 저장된 경로 북마크</h3>";
		html+= "<h6 style='text-align:center;'>저장된 경로를 지도에서 확인하려면 북마크제목을 클릭하세요</h6><hr><br>";
		for(var i=0; i<data.list.length; i++){
			
			json.bmrtseq = data.list[i].BM_RT_SEQ;
			
			var datart2 = getAjax("/board/selectBMRoute2.json", json);
			
			html += "<a href=# onclick='showBMroute("+data.list[i].BM_RT_SEQ+")' style='color : black; text-decoration:none;'>" 
					+ i + "번째 북마크 : " +  datart2.list[0].BM_NICK + "</a> <a href=# onclick='removeBM("+data.list[i].BM_RT_SEQ+", "+i+")'style='color : black; text-decoration:none;'>" 
					+ "X</a><br>";
		}
		$("#bookmark").html(html);
 });
 
 function removeBM(getbmrtseq, i){
	 if(confirm(" 북마크 번호"+ i +" 를 정말 삭제하시겠습니까?")){
			
		json={};
		json.mid = userId;
		json.bmrtseq = getbmrtseq;
		var datart2 = getAjax("/board/deleteBookmarkRoute.json", json);
			
		if(datart2.removeInfo == true) {
			alert("게시글 삭제가 완료되었습니다.");
			location.href = "/Bookmark.do?userId="+userId;
		}else {
			alert("북마크 삭제가 제대로 시행되지 않았습니다. 다시 시도해주세요.");
		}
			
	}else{
		
		return false;
	}
	 
 }
 
 function showBMroute(getbmrtseq){
	 	waypts=[];
		console.log(getbmrtseq);
		json={};
		json.mid = userId;
		json.bmrtseq = getbmrtseq;
		var datart2 = getAjax("/board/selectBMRoute2.json", json);
		
		for(var j=0; j<datart2.list.length; j++){
			DepartPosition = new google.maps.LatLng(datart2.list[0].BM_RT_DEP_LAT, datart2.list[0].BM_RT_DEP_LNG);
			ArrivePosition = new google.maps.LatLng(datart2.list[0].BM_RT_ARR_LAT, datart2.list[0].BM_RT_ARR_LNG);
			
			if(datart2.list[j].BM_RT_WAYPO_LAT != undefined && datart2.list[j].BM_RT_WAYPO_LNG != undefined){
				wp = new google.maps.LatLng(datart2.list[j].BM_RT_WAYPO_LAT, datart2.list[j].BM_RT_WAYPO_LNG);
     
       		waypts.push({
                   location: wp,
                   stopover: true
                 }); 
			}else{
				waypts=[];
			}
		}
		
		 var selectedMode = 'DRIVING';
		
		
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
		
	}

 function doDisplay(){
		
		var divNavigator = document.getElementById("navigator");
		
		if(divNavigator.style.display == 'none'){	// 열기
			divNavigator.style.display = 'block';
			$("#textinput").text("길찾기 닫기(클릭)");
		}else{										// 닫기			
			divNavigator.style.display = 'none';
			$("#textinput").text("길찾기 자세히보기(클릭)");
		}
		
	}
 
 
 
 
 </script>