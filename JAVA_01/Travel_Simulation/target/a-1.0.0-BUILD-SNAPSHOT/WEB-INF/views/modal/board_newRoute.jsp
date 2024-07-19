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
        background-color: #fff;
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
        margin-left: 12px;
        padding: 0 11px 0 13px;
        text-overflow: ellipsis;
        width: 400px;
        height : 30px;
      }

      #pac-input:focus {
        border-color: #4d90fe;
      }

    </style>

		<div id="floating-panel">
			<b>경로 모드: </b>
			<select id="mode">
				<option value="DRIVING">Driving</option>
				<option value="WALKING">Walking</option>
				<option value="BICYCLING">Bicycling</option>
				<option value="TRANSIT">Transit</option>
			</select>
		</div>
		<div id="right-panel" >
		<p>경로 최적화란 : 경유지를 선택하신 순서가 아닌 최적화 된 순서로 변경합니다.</p>
			<b>경로 최적화 : </b>
			<select id="optimize" style="width:100px;">
				<option value="true">허용</option>
				<option value="false">비허용</option>
			</select>
			<input type="text" id="inputRouteNick" placeholder="북마크 제목">
			<button type="button" class="btn btn-primary" id="BookmarkRouteBtn">경로 북마크하기</button>
			<p><button type="button" class="btn btn-parimary" id="closeWin">창 닫기</button></p>
			<a href ='javascript:doDisplay();' style="color : black; text-decoration:none; text-align : center;">
				<p id="textinput">길찾기 자세히보기(클릭)</p>
			</a>
			<div id="navigator" style="display:none;">
			</div>
		</div>
		
		<input id="pac-input" class="controls" type="text" placeholder="Search Box">
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
	
	
	
	
	
	var place, places, map, infowindow, myLatLng, markers_mk, marker1, wp;
	var mylat, mylng, curlat, curlng, currentpos;
	var DepartPosition, ArrivePosition, input, searchBox, currentpos, contentString, contentString2;
	var markers=[];
	var markers2=[];
	var InforObj = [];
	var map = new google.maps.Map(document.getElementById('map'), {
    	center: {lat: 37.77, lng: -122.447},
    	zoom: 13,
    	mapTypeId: 'roadmap'
  	});
	var directionsRenderer = new google.maps.DirectionsRenderer;
	var directionsService = new google.maps.DirectionsService; 
	var service = new google.maps.places.PlacesService(map);
	var waypts = [];
	var wpts = [];
	var infowindow = new google.maps.InfoWindow;
	var infowindow1 = new google.maps.InfoWindow;
	var infowindow2 = new google.maps.InfoWindow;
	var infowindow3 = new google.maps.InfoWindow;
	var getbmrtseq, mid;
	var userId;

	
	$(document).ready(function(){
		
		load();
		
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

      
	});//END DOCU READY
	
	
	
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
	
	
	$("#closeWin").on("click", function(){
		
		opener.window.location.reload()
		 self.close()
		
	});
	
	
	$("#BookmarkRouteBtn").on("click", function(){		
    	
		if(DepartPosition != null){
			console.log("");
			console.log("----------------------------------------------------");
			console.log("---------Bookmark Route Button Click Console.log---------");
			console.log("----------------------------------------------------");
	        console.log("출발위치 lat, lng");															
	        console.log(DepartPosition.lat() +","+DepartPosition.lng());
	        
	        for(var i=0;i<waypts.length;i++){
	      	  console.log("경유지 위치 lat, lng");
	      	  console.log(waypts[i].location.lat() + ","+waypts[i].location.lng());
	        }
	        console.log("목표위치 lat, lng");
	        console.log(ArrivePosition.lat() +","+ ArrivePosition.lng());
	        console.log("----------------------------------------------------");
		
	        
	        
	        
	        json={};
			json.mid = userId;
			console.log(json.mid);
			var data = getAjax("/board/selectbookmarkseq.json", json);
			
			console.log(data.list[0].NEXTVAL);
			
			json.bmrtseq= data.list[0].NEXTVAL;
			var Nick = $("#inputRouteNick").val();
			
			if(Nick==""){
				json.bmnick="";
			}else{
				json.bmnick = $("#inputRouteNick").val();
			}
			
			json.bmdeplat = DepartPosition.lat();
			json.bmdeplng = DepartPosition.lng();
			json.bmarrlat = ArrivePosition.lat();
			json.bmarrlng = ArrivePosition.lng();
			
			if(waypts.length>0){
				console.log("여기");
				for(var j=0;j<waypts.length;j++){
					console.log("here");
            
					console.log(waypts[j].location.lat() + ","+waypts[j].location.lng());
					
		      		json.bmwaypolat = waypts[j].location.lat();
					json.bmwaypolng = waypts[j].location.lng();
					var data = getAjax("/board/insertBookmark.json", json);	
		        }
			}else{
				json.bmdeplat = DepartPosition.lat();
				json.bmdeplng = DepartPosition.lng();
				json.bmarrlat = ArrivePosition.lat();
				json.bmarrlng = ArrivePosition.lng();
				
				json.bmwaypolat = "";
				json.bmwaypolng = "";
				var data = getAjax("/board/insertBookmark.json", json);	
			}
		    
			
			if(data.addBookmark == true){
				alert("북마크 저장이 성공적으로 완료되었습니다.");
				location.href = "./board_newRoute.do?userId="+mid;
			}else{
				alert("경로 저장에 실패하였습니다.");
				return;
			}
		
		}else{
			alert("저장하려는 여행 경로를 완성하세요.");
		}
	});
	
	
	

	
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
      	input = document.getElementById('pac-input');
      	searchBox = new google.maps.places.SearchBox(input);
      	map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
      	
    
      	
      	// Bias the SearchBox results towards current map's viewport.
      	map.addListener('bounds_changed', function() {
        	searchBox.setBounds(map.getBounds());
      	});

      	// Listen for the event fired when the user selects a prediction and retrieve
      	// more details for that place.
      	searchBox.addListener('places_changed', function() {
        	places = searchBox.getPlaces();
        	
        
        	if (places.length == 0) {
          		return;
        	}
			
        	// Clear out the old markers.
       		markers.forEach(function(marker) {
          		marker.setMap(null);
        	});
        	markers = [];

        	// For each place, get the icon, name and location.
        	var bounds = new google.maps.LatLngBounds();
        	places.forEach(function(place) {
          		if (!place.geometry) {
            		console.log("Returned place contains no geometry");
            		return;
          		}
          
          		var icon = {
            		url: place.icon,
            		size: new google.maps.Size(71, 71),
            		origin: new google.maps.Point(0, 0),
            		anchor: new google.maps.Point(17, 34),
            		scaledSize: new google.maps.Size(25, 25)
          		};
			
          		// Create a marker for each place.
          		const markers_mk = new google.maps.Marker({
            		map: map,
            		icon: icon,
            		title: place.name,
            		position: place.geometry.location,
            		address: place.formatted_address
          		}); markers.push(markers_mk);	//검색 마커
          
          		google.maps.event.addListener(markers_mk, 'click', function() {		// 검색 ㅁㅏ커 선택시
          			//markers.forEach(function(marker) {
              			//    marker.setMap(null);
              		//});															//검색마커 없어지고
            
            	
          			contentString = "<div style='text-align : center;'><strong>"+place.name+"</strong><br>"+place.formatted_address+"<br>"
          							+ "<button type='button' onclick='departBtnclick()' >출발지로 설정</button>"
            							+ "<button type='button' onclick='arriveBtnclick()'>도착지로 설정</button>"
            							+ "<button type='button' onclick='addWayPoint()'>경유지로 설정</button></div>";
            							
            			
            		DepartPosition = new google.maps.LatLng(curlat, curlng);
              		infowindow = new google.maps.InfoWindow({
              			content: contentString,
                  		maxWidth: 200
              		});
                    //closeOtherInfo();
              		infowindow.open(markers_mk.get('map'), markers_mk);
              		InforObj[0] = infowindow;
              		
              		
            	
           		});	//end click markers_mk
          
          
          		if (place.geometry.viewport) {
              		// Only geocodes have viewport.
              		bounds.union(place.geometry.viewport);
            	} else {
              		bounds.extend(place.geometry.location);
            	}
          });
          map.fitBounds(bounds);
          
          
      });//end searchbox places_changed
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
    
		function arriveBtnclick() {					// 도착지로 설정
			
			closeOtherInfo();
			DepartPosition = null;
			ArrivePosition = null;
			
			DepartPosition = new google.maps.LatLng(curlat, curlng);	// 현재위치 출발
		
	    	mylat = markers[0].position.lat();
	    	mylng = markers[0].position.lng();				 
			
			ArrivePosition = new google.maps.LatLng(mylat, mylng);		// 마커위치 도착
	    	
	    	calculateAndDisplayRoute(directionsService, directionsRenderer);			// 루트검색
	        document.getElementById('mode').addEventListener('change', function() {	// 이동방법 변경시
	          calculateAndDisplayRoute(directionsService, directionsRenderer);		// 루트검색
	        });
	        document.getElementById('optimize').addEventListener('change', function() {	// 이동방법 변경시
	        	calculateAndDisplayRoute(directionsService, directionsRenderer);		// 루트검색
		        });
	    	
		} // end arriveBtnclick()
	
	
	
	
	
	
	
		
		function departBtnclick() {					//출발지로 설정
			marker1.setMap(null);
			DepartPosition = null;
			ArrivePosition = null;
			
	      	
	      	closeOtherInfo();
	      	
	      	contentString = "<div style='text-align : center;'<p>출발지</p><p>"+markers[0].title+"</p><p>"+markers[0].address+"</p><p>도착지 또는 경유지를 검색하세요</p></div>" ;
	      	infowindow = new google.maps.InfoWindow({
          			content: contentString,
              		maxWidth: 200
          		});
	      	
	      	infowindow.open(map, markers[0]);
      		InforObj[0] = infowindow;
	      	
      		
      		DepartPosition = new google.maps.LatLng(markers[0].position.lat(), markers[0].position.lng());
      		
      		
      		$('#pac-input').val("");
	      	searchBox = new google.maps.places.SearchBox(input);
	      	$('#pac-input').attr("placeholder", "도착지 또는 경유지를 검색하세요");
      		
	      	// Bias the SearchBox results towards current map's viewport.
	      	map.addListener('bounds_changed', function() {
	        	searchBox.setBounds(map.getBounds());
	      	});

	      	// Listen for the event fired when the user selects a prediction and retrieve
	      	// more details for that place.
	      	searchBox.addListener('places_changed', function() {
	        	places = searchBox.getPlaces();
	        
	        	if (places.length == 0) {
	          		return;
	        	}

	        	markers2 = [];

	        	// For each place, get the icon, name and location.
	        	var bounds = new google.maps.LatLngBounds();
	        	places.forEach(function(place) {
	          		if (!place.geometry) {
	            		console.log("Returned place contains no geometry");
	            		return;
	          		}
	          
	          		var icon = {
	            		url: place.icon,
	            		size: new google.maps.Size(71, 71),
	            		origin: new google.maps.Point(0, 0),
	            		anchor: new google.maps.Point(17, 34),
	            		scaledSize: new google.maps.Size(25, 25)
	          		};
				
	          		// Create a marker for each place.
	          		var markers2_mk = new google.maps.Marker({
	            		map: map,
	            		icon: icon,
	            		title: place.name,
	            		position: place.geometry.location,
	            		address: place.formatted_address
	          		}); markers2.push(markers2_mk);	//검색 마커
	          
	          		google.maps.event.addListener(markers2_mk, 'click', function() {		// 검색 ㅁㅏ커 선택시
	
						closeOtherInfo();
						
	          			contentString2 =	"<div style='text-align : center;'><strong>"+place.name+"</strong><br>"+place.formatted_address+"<br>" 
	          							+"<button type='button' onclick='arriveBtnclick2()'>도착지로 설정</button>"
	          							+ "<button type='button' onclick='addWayPoint()'>경유지로 설정</button></div>";
	            							
	            			
	            		
	              		infowindow = new google.maps.InfoWindow({
	              			content: contentString2,
	                  		maxWidth: 200
	              		});
	                    //closeOtherInfo();
	              		infowindow.open(markers2_mk.get('map'), markers2_mk);
	              		InforObj[0] = infowindow;
	              		
	              		
	            	
	           		});	//end click markers_mk
	           		
	          
	          		if (place.geometry.viewport) {
	              		// Only geocodes have viewport.
	              		bounds.union(place.geometry.viewport);
	            	} else {
	              		bounds.extend(place.geometry.location);
	            	}
	          });
	          map.fitBounds(bounds);
	          
	          
	      });//end searchbox places_changed
			
		} // end departBtnclick()
		
		
		
		
		
		
		
		
		function addWayPoint(){
			
			closeOtherInfo();
	
			
			if(DepartPosition.lat() !== curlat && DepartPosition.lng() !== curlng){		// start point !== my current position
				
				var z = waypts.length;		// start from 0
				
				
				if(z>0){		// has waypoints
					
					wp = new google.maps.LatLng(markers2[z].position.lat(), markers2[z].position.lng());
					console.log("출발지는 검색 된 위치");
					
					contentString = "<div style='text-align : center;'<p>경유지</p><p>"+markers2[z].title+"</p><p>"+markers2[z].address+"</p><p>도착지 또는 경유지를 검색하세요</p></div>" ;
			      	infowindow = new google.maps.InfoWindow({
		      			content: contentString,
		          		maxWidth: 200
		      		});
		      	
		      		infowindow.open(map, markers2[z]);
		      		InforObj[0] = infowindow;
		      		
		      		waypts.push({
			              location: wp,
			              stopover: true
			            });
					
					
				}else{			// depart point -> arrive point		or		first waypoint
					
					wp = new google.maps.LatLng(markers2[0].position.lat(), markers2[0].position.lng());
					console.log("출발지는 검색 된 위치");
					
					contentString = "<div style='text-align : center;'<p>경유지</p><p>"+markers2[0].title+"</p><p>"+markers2[0].address+"</p><p>도착지 또는 경유지를 검색하세요</p></div>" ;
			      	infowindow = new google.maps.InfoWindow({
		      			content: contentString,
		          		maxWidth: 200
		      		});
		      	
		      		infowindow.open(map, markers2[0]);
		      		InforObj[0] = infowindow;
		      	
		      		waypts.push({
		              	location: wp,
		              	stopover: true
		            	});
		      	
				}
				
				
			}else if(DepartPosition.lat()==curlat && DepartPosition.lng() == curlng){					// current point = start point
				
				var z = waypts.length;		// start from 0
				
				
				if(z>0){				// 경유지가 두번째 이상
					wp = new google.maps.LatLng(markers2[z-1].position.lat(), markers2[z-1].position.lng());
					console.log("출발지는 현재위치");
					
					contentString = "<div style='text-align : center;'<p>경유지</p><p>"+markers2[z-1].title+"</p><p>"+markers2[z-1].address+"</p><p>도착지 또는 경유지를 검색하세요</p></div>" ;
			      	infowindow = new google.maps.InfoWindow({
		      			content: contentString,
		          		maxWidth: 200
		      		});
		      	
		      		infowindow.open(map, markers2[z-1]);
		      		InforObj[0] = infowindow;
		      		
		      		waypts.push({
			              location: wp,
			              stopover: true
			            });
				}else{						// markers[0] = waypoint1
					wp = new google.maps.LatLng(markers[0].position.lat(), markers[0].position.lng());
					console.log("출발지는 현재위치");
					
					contentString = "<div style='text-align : center;'<p>경유지</p><p>"+markers[0].title+"</p><p>"+markers[0].address+"</p><p>도착지 또는 경유지를 검색하세요</p></div>" ;
			      	infowindow = new google.maps.InfoWindow({
		      			content: contentString,
		          		maxWidth: 200
		      		});
		      	
		      		infowindow.open(map, markers[0]);
		      		InforObj[0] = infowindow;
		      		
		      		waypts.push({
			              location: wp,
			              stopover: true
			            });
				}
						
			}else{}
			
		          $('#pac-input').val("");
			      searchBox = new google.maps.places.SearchBox(input);
			      $('#pac-input').attr("placeholder", "도착지 또는 경유지를 검색하세요");
			      
			   // Bias the SearchBox results towards current map's viewport.
			      	map.addListener('bounds_changed', function() {
			        	searchBox.setBounds(map.getBounds());
			      	});

			      	// Listen for the event fired when the user selects a prediction and retrieve
			      	// more details for that place.
			      	searchBox.addListener('places_changed', function() {
			        	places = searchBox.getPlaces();
			        
			        	if (places.length == 0) {
			          		return;
			        	}
						

			        	// For each place, get the icon, name and location.
			        	var bounds = new google.maps.LatLngBounds();
			        	places.forEach(function(place) {
			          		if (!place.geometry) {
			            		console.log("Returned place contains no geometry");
			            		return;
			          		}
			          
			          		var icon = {
			            		url: place.icon,
			            		size: new google.maps.Size(71, 71),
			            		origin: new google.maps.Point(0, 0),
			            		anchor: new google.maps.Point(17, 34),
			            		scaledSize: new google.maps.Size(25, 25)
			          		};
						
			          		// Create a marker for each place.
			          		markers2_mk = new google.maps.Marker({
			            		map: map,
			            		icon: icon,
			            		title: place.name,
			            		position: place.geometry.location,
			            		address: place.formatted_address
			          		}); markers2.push(markers2_mk);	//검색 마커
			          
			          		google.maps.event.addListener(markers2_mk, 'click', function() {		// 검색 ㅁㅏ커 선택시

			            		closeOtherInfo();
							
								
			          			contentString2 = "<div style='text-align : center;'><strong>"+place.name+"</strong><br>"+place.formatted_address+"<br>"
			          							+ "<button type='button' onclick='arriveBtnclick2()'>도착지로 설정</button>"
			          							+ "<button type='button' onclick='addWayPoint()'>경유지로 설정</button></div>";
			            							
			            			
			            		
			              		infowindow = new google.maps.InfoWindow({
			              			content: contentString2,
			                  		maxWidth: 200
			              		});
			              		infowindow.open(markers2_mk.get('map'), markers2_mk);
			              		InforObj[0] = infowindow;
			              		
			              		
			            	
			           		});	//end click markers_mk
			           		
			          
			          		if (place.geometry.viewport) {
			              		// Only geocodes have viewport.
			              		bounds.union(place.geometry.viewport);
			            	} else {
			              		bounds.extend(place.geometry.location);
			            	}
			          });
			          map.fitBounds(bounds);
			          
			          
			      });//end searchbox places_changed
			
		}// end addWayPoint()
		
		
		
		
		
		
		function arriveBtnclick2(){			// wayPoint -> ArrivePoint		 or 	Searched DepartPoint -> ArrivePoint
			
			closeOtherInfo();
			optimizeMode = document.getElementById('optimize').value;
			var z = waypts.length;
					// end point = markers2[]
		
			if (z >0){			// wayPoint -> ArrivePoint which has waypts
				
				if (z == markers2.length ){
					
					
					contentString2 = "<div style='text-align : center;'><p>도착지</p><p>"+markers2[z-1].title+"</p><p>"+markers2[z-1].address+"</p></div>";
			      	
			      	infowindow = new google.maps.InfoWindow({
		          			content: contentString2,
		              		maxWidth: 200
		          		});
			      	infowindow.open(map, markers2[z-1]);
		      		InforObj[0] = infowindow;
		  			ArrivePosition = new google.maps.LatLng(markers2[z-1].position.lat(), markers2[z-1].position.lng());
					
				}else{
					
					contentString2 = "<div style='text-align : center;'><p>도착지</p><p>"+markers2[z].title+"</p><p>"+markers2[z].address+"</p></div>";
			      	
			      	infowindow = new google.maps.InfoWindow({
		          			content: contentString2,
		              		maxWidth: 200
		          		});
			      	infowindow.open(map, markers2[z]);
		      		InforObj[0] = infowindow;
		  			ArrivePosition = new google.maps.LatLng(markers2[z].position.lat(), markers2[z].position.lng());
				}
				
	  			
			}else{						//Searched DepartPoint -> ArrivePoint
				
				contentString2 = "<div style='text-align : center;'><p>도착지</p><p>"+markers2[0].title+"</p><p>"+markers2[0].address+"</p></div>";
		      	
		      	infowindow = new google.maps.InfoWindow({
	          			content: contentString2,
	              		maxWidth: 200
	          		});
		      	infowindow.open(map, markers2[0]);
	      		InforObj[0] = infowindow;
	  			ArrivePosition = new google.maps.LatLng(markers2[0].position.lat(), markers2[0].position.lng());
				
			}
			
		
	    	
	    	
	    	
			if(ArrivePosition != null){
				calculateAndDisplayRoute(directionsService, directionsRenderer);			// 루트검색
		        document.getElementById('mode').addEventListener('change', function() {	// 이동방법 변경시
		        	calculateAndDisplayRoute(directionsService, directionsRenderer);		// 루트검색
		        });
		        document.getElementById('optimize').addEventListener('change', function() {	// 경로최적화 변경시
		        	calculateAndDisplayRoute(directionsService, directionsRenderer);		// 루트검색
			        });
			}else{
				
			}
			
  		}// end arriveBtnclick2()
	
		
		
  		
  		
		
      function closeOtherInfo() {
          if (InforObj.length > 0) {
              InforObj[0].set("marker", null);
              InforObj[0].close();
              InforObj.length = 0;
          }
      }
      
      
  		
  		
  		
      
  	
      function calculateAndDisplayRoute(directionsService, directionsRenderer) {
    	  
    	  
    	infowindow1.close();
        infowindow2.close();
        for(i=0;i<infowindow3.length;i++){
        	infowindow3[i].close();
        }
        
        	infowindow.close();
        	closeOtherInfo();								// 모든 info window를 끄기위함
        
    	
    	
    	
    	
    	
        var selectedMode = document.getElementById('mode').value;
        var optimize = document.getElementById('optimize').value;
        
        console.log("optimize option : "+optimize);
        
        if(optimize == "true"){
        	optimizeMode = true;
        	
        }else{
        	optimizeMode = false;
        }
        
          directionsService.route({
            origin: DepartPosition , 															// 현재위치를 출발점으로 설정
            destination: ArrivePosition,
            waypoints: waypts,
            optimizeWaypoints: optimizeMode,
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

          
          
          
          
          
          //----------------------------------------------
          
          
        
        
         
          
       // Bias the SearchBox results towards current map's viewport.
        	map.addListener('bounds_changed', function() {
          	searchBox.setBounds(map.getBounds());
        	});

        	// Listen for the event fired when the user selects a prediction and retrieve
        	// more details for that place.
        	searchBox.addListener('places_changed', function() {

        		
          	places = searchBox.getPlaces();
          	
          	
          	

          	for(var i=0; i<markers2.length ; i++){
          		markers2[i].setMap(null);
          	}
          	markers2=[];
          	var ArrivePosition;
          	waypts = [];
          	
          	closeOtherInfo();
          	infowindow1.close();
          	infowindow2.close();
          	for(i=0;i<infowindow3.length;i++){
          		 infowindow3[i].close();
          	 }
          	
       
          	markers.forEach(function(marker1) {
    		    marker1.setMap(null);
    		});
            markers.forEach(function(markers) {
    		    markers.setMap(null);
    		});
            markers2.forEach(function(markers2) {
    		    markers2.setMap(null);
    		});

            
          	if (places.length == 0) {
            		return;
          	}
  			
          	// Clear out the old markers.
         	
          	markers = [];

          	// For each place, get the icon, name and location.
          	var bounds = new google.maps.LatLngBounds();
          	places.forEach(function(place) {
          		
              	
            		if (!place.geometry) {
              		console.log("Returned place contains no geometry");
              		return;
            		}
            
            		var icon = {
              		url: place.icon,
              		size: new google.maps.Size(71, 71),
              		origin: new google.maps.Point(0, 0),
              		anchor: new google.maps.Point(17, 34),
              		scaledSize: new google.maps.Size(25, 25)
            		};
  			
            		// Create a marker for each place.
            		const markers_mk = new google.maps.Marker({
              		map: map,
              		icon: icon,
              		title: place.name,
              		position: place.geometry.location
            		}); markers.push(markers_mk);	//검색 마커
            
            		google.maps.event.addListener(markers_mk, 'click', function() {		// 검색 ㅁㅏ커 선택시
              
              	
            			contentString = "<div style='text-align : center;'><strong>"+place.name+"</strong><br>"+place.formatted_address+"<br>"
            							+ "<button type='button' onclick='departBtnclick()' >출발지로 설정</button>"
              							+ "<button type='button' onclick='arriveBtnclick()'>도착지로 설정</button>"
              							+ "<button type='button' onclick='addWayPoint()'>경유지로 설정</button></div>";
              							
              			
              		DepartPosition = new google.maps.LatLng(curlat, curlng);
                		infowindow = new google.maps.InfoWindow({
                			content: contentString,
                    		maxWidth: 200
                		});
                      //closeOtherInfo();
                		infowindow.open(markers_mk.get('map'), markers_mk);
                		InforObj[0] = infowindow;
                		
                		
              	
             		});	//end click markers_mk
            
            
            		if (place.geometry.viewport) {
                		// Only geocodes have viewport.
                		bounds.union(place.geometry.viewport);
              	} else {
                		bounds.extend(place.geometry.location);
              	}
            });
            map.fitBounds(bounds);
            
            
        });//end searchbox places_changed
       
          
      }

 
 
 
 
 </script>