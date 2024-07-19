<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

  
<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBM3YAiv6ptli8_XfGpVyb6Koy0Ivjxl2Q&libraries=places&region=kr"></script> 
	<script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>
	<script src="../../resources/js/common/bPopup.js?ver=1.0" type="text/javascript"></script>


<style>
 /* Optional: Makes the sample page fill the window. */
 		#map {
      	  height: 600px;
  	    }
  	    html,
  	    body {
 	       height: 100%;
 	       margin: 0;
 	       padding: 0;
	    }
        
        div.wrap {
            width: 200px;
        }
        div.text-box {
            text-align: center;
        }

        div.img-box {
            max-height: 100px;
            overflow: hidden;
        }
        img {
            width: 150px;
            
        }
        a {
            text-decoration: none;
            color: #000;
        }
        
        #mainPage tr {
	 		height : 30px;
			margin : auto;
			vertical-align: center;
		}
			
		#mainPage td {
			text-align:center; 
			margin : auto;
			vertical-align: center;
		}
		#mainPage th {
			font-weight : bold;
			text-align : center;
			margin : auto;
			vertical-align: center;
		}
		
		#mainPage table { 
			width : 100%;
			margin : auto;
			text-align: center;
		}

 		.gmnoprint, .gm-control-active.gm-fullscreen-control {
            display: none;
 		 }
  
 		 .btn_like {
			  position: absolute;
			  display: block;
			  width: 44px;
			  height: 44px;
			  border: 1px solid #e8e8e8;
			  border-radius: 44px;
			  font-family: notokr-bold,sans-serif;
			  font-size: 14px;
			  line-height: 16px;
			  background-color: #fff;
			  color: #DD5D54;
			  box-shadow: 0 2px 2px 0 rgba(0,0,0,0.03);
			  transition: border .2s ease-out,box-shadow .1s ease-out,background-color .4s ease-out;
			  cursor: pointer;
			}
			
			.btn_like:hover {
			  border: 1px solid rgba(228,89,89,0.3);
			  background-color: rgba(228,89,89,0.02);
			  box-shadow: 0 2px 4px 0 rgba(228,89,89,0.2);
			}
			
			.btn_unlike .img_emoti {
			    background-position: -30px -120px;
			}
			
			.img_emoti {
			    display: inline-block;
			    overflow: hidden;
			    font-size: 0;
			    line-height: 0;
			    background: url(https://mk.kakaocdn.net/dn/emoticon/static/images/webstore/img_emoti.png?v=20180410) no-repeat;
			    text-indent: -9999px;
			    vertical-align: top;
			    width: 20px;
			    height: 17px;
			    margin-top: 1px;
			    background-position: 0px -120px;
			    text-indent: 0;
			}

		#element_to_pop_up { 
		    background-color:#fff;
		    border-radius:15px;
		    color:#000;
		    display:none; 
		    padding:20px;
		    min-width:200px;
		    min-height: 180px;
		}
		.b-close{
		    cursor:pointer;
		    position:absolute;
		    right:10px;
		    top:5px;
		}
		.myTrip{width: 88%; background-color: rgb(255, 255, 255); padding-left: 0px; padding-right: 0px; font-size: 13px;}
		.myTrip_del{width: 10%;background-color: white;border-left-width: 0px;padding-top: 1px;padding-right: 12px;padding-left: 5px; font-size: 13px;}
		
		.addbtn {
			box-shadow:inset 0px 1px 0px 0px #ffffff;
			background:linear-gradient(to bottom, #ffffff 5%, #f6f6f6 100%);
			background-color:#ffffff;
			border-radius:21px;
			border:1px solid #dcdcdc;
			display:inline-block;
			cursor:pointer;
			color:#666666;
			font-family:Arial;
			font-size:20px;
			padding:0px 9px;
			text-decoration:none;
			text-shadow:0px 1px 0px #ffffff;
		}
		.addbtn:hover {
			background:linear-gradient(to bottom, #f6f6f6 5%, #ffffff 100%);
			background-color:#f6f6f6;
		}
		.addbtn:active {
			position:relative;
			top:1px;
		}
		
		.addtext{
		    border-left-width: 0px;
		    border-top-width: 0px;
		    border-right-width: 0px;
		}

		select {

		    width: 200px; /* 원하는 너비설정 */
		    padding: .80em .50em; /* 여백으로 높이 설정 */
		    font-family: inherit;  /* 폰트 상속 */
		    background-color: #fff;
		    border: 1px solid #999;
		    border-radius: 10px; /* iOS 둥근모서리 제거 */
		    -webkit-appearance: none; /* 네이티브 외형 감추기 */
		    -moz-appearance: none;
		    appearance: none;
	    
		}
 	 	@media (min-width: 1000px){ 

			.bodySide{
				width: 15%;
			}

	 	}  
	 	@media (min-width: 760px){ 
			#bodyDiv .card-img-top{
				height:15vw;
			}
		}  
	 	

</style>    

<div id="mainPage">

	<ul class="nav nav-tabs">
		<li class="nav-item">
			<a class="nav-link active" data-toggle="tab" href="#mapDiv">여행 지도</a>
		</li>
		<li class="nav-item">
			<a class="nav-link" data-toggle="tab" href="#recommDestination">추천 여행지</a>
		</li>
		<li class="nav-item">
			<a class="nav-link" data-toggle="tab" href="#TravelReview">여행 후기</a>
		</li>
	</ul>
	
	<div id="myTabContent" class="tab-content">
		
		<!-- 여행지도 탭 -->
		<div class="tab-pane fade active show" id="mapDiv">
			<div id="locationSerch">
				<select id="continent" name="continent" onChange="chnQnaType(this.value)" style="display:inline-block; text-overflow:ellipsis;" class="custom-select">
					<option value="none">대륙을 선택해주세요.</option>
					<option value="아시아">아시아</option>
					<option value="동남아시아">동남아시아</option>
					<option value="유럽">유럽</option>
					<option value="북아메리카">북아메리카</option>
				</select>
				<select id="countrys" name="countrys" class="custom-select" style="text-overflow:ellipsis;">
					<option value='none'>나라를 선택해주세요.</option>
				</select>
				<button id="ctySelectBtn" class="btn btn-primary">검색</button>	
			</div> 
			<!-- Jumbotron Header -->
			<header class="jumbotron my-4" style="padding-left: 0px; padding-right: 0px;margin-top: 0px !important;padding-top: 0px; padding-bottom: 0px; margin-bottom: 0px !important; overflow: hidden; ">
		    	<div>
		    		<table id="infobtn">
		    			<tr>
		    				<th colspan="4" class="alertInfo">
		    					정보를 조회하려면 해당 정보버튼을 클릭후 국기 아이콘을 클릭하세요
		    				</th>
		    			</tr>
		    			<tr>
		    				<td style="width:30px;boarder:0 0 0 0; margin-left:10px;">
		    					<img src="./img/back.png" style="width:50px;margin-left:0;" id="back" alt="">
		    				</td>
		    				<td>
		    					<button type="button" class="btn btn-primary" id="NTbtn">국가</button>
		    					<button type="button" class="btn btn-primary" id="TAbtn">여행지</button>
		    					<button type="button" class="btn btn-primary" id="HTbtn">숙소</button>
		    					<button type="button" class="btn btn-primary" id="ExchRonbtn">환율</button>
		    				</td>
		    			</tr>
		    		</table>
		    		<div id="ExchRontd" style="display:none;">
		    			<div id="ExchRon" style="float: right;">
		    				<div>
			    				<button type="button" class="btn btn-primary" id="exchangebtn" style="float: right;">변경</button>
			    				<span id="insertTo" style="padding-left:5px;font-weight:bold;color:#2D6AB4; position:relative; top:5px; float: right;margin-top: 3px;"></span>
								<div id="fxexchangerateResult" style="font-weight:bold;font-size:26px; width: 302px; height: 40px; color:#aaa; text-align:center;"></div>
							</div>
							<div>
								<button type="button" class="btn btn-primary" id="ExchRonclosebtn" style="float: right;">닫기</button>
								<span id="fxspanfm" style="padding-left:5px;font-weight:bold;color:#2D6AB4; position:relative; top:5px; float: right; ">KRW</span>
								<input value="1" type="text" id="fxexchangerateAmount" style="width: 30%; margin-right: 20px; display: inline-block; float: right; margin-top: 7px; border: 1px solid #ccc;box-shadow: inset 0 1px 3px #ddd;font-size: 11px;border-radius: 4px;vertical-align: middle;-moz-box-sizing:border-box;box-sizing: border-box;" onkeyup="getfxexchangerate(); return false;"/>		
							</div>
						</div>
					</div>
		    	</div>	    	
		      	<div id="map">
		      	</div>					      	
		    </header>
		</div>
	  
	  	<!-- 추천 여행지 탭 -->
		<div class="tab-pane fade" id="recommDestination">
			<center><h1>추천 여행지</h1></center>
		    <div class="row text-center" id="bodyDiv" style="max-width: 90%; margin-left: 5%;padding-left:15px;padding-right:15px;">
		    
		    </div>
		</div>
	  
	  	<!-- 여행 후기 탭 -->
		<div class="tab-pane fade" id="TravelReview">
			<center><h1>여행 후기</h1></center> 
			<div class="row text-center" style="max-width: 90%; margin-left: 5%;padding-left:15px;padding-right:15px;">
	    	  	<div class="col-lg-3 col-md-6 mb-4">
	    	    	<div class="card h-100" id="carddiv0">
	         
	    	    	</div>
	    		</div>
	
				<div class="col-lg-3 col-md-6 mb-4">
	   	    		<div class="card h-100" id="carddiv1">
	         	 
	       		 	</div>
				</div>
	
				<div class="col-lg-3 col-md-6 mb-4">
	      		  	<div class="card h-100" id="carddiv2"></div>
	   		   	</div>
	
	      		<div class="col-lg-3 col-md-6 mb-4">
	     	   		<div class="card h-100" id="carddiv3"></div>
	      		</div>
			</div>	
		</div>
	  
		<div class="tab-pane fade" id="dropdown1">
			<p>Etsy mixtape wayfarers, ethical wes anderson tofu before they sold out mcsweeney's organic lomo retro fanny pack lo-fi farm-to-table readymade. Messenger bag gentrify pitchfork tattooed craft beer, iphone skateboard locavore carles etsy salvia banksy hoodie helvetica. DIY synth PBR banksy irony. Leggings gentrify squid 8-bit cred pitchfork.</p>
		</div>
		<div class="tab-pane fade" id="dropdown2">
			<p>Trust fund seitan letterpress, keytar raw denim keffiyeh etsy art party before they sold out master cleanse gluten-free squid scenester freegan cosby sweater. Fanny pack portland seitan DIY, art party locavore wolf cliche high life echo park Austin. Cred vinyl keffiyeh DIY salvia PBR, banh mi before they sold out farm-to-table VHS viral locavore cosby sweater.</p>
		</div>
	</div>	
	
	<ul style="list-style:none; margin:0; padding:0; width:100%; display:flex;">
		<li style="width: 100%;">
			<div class="container" ></div>
			<!--  End of Currency Converter Script -  FxExchangeRate.com -->
		</li>
	</ul>
	
	<div id="ExchangeRate" style="position: absolute;top: 136px;right: 0px; border: 1px solid #000; display:none;  background-color: #ffffff;">
		<div style="width: 190px;height:auto;border:1px solid #2D6AB4;text-align:center;font-size: 11px;font-family:sans-serif,Arial,Helvetica;border-top-right-radius:5px;border-top-left-radius:5px;background-color:#FFFFFF;">
			<div style="width:100%;height: 25px;padding:5px 0px 0px 0px;background-color:#2D6AB4;font-weight:bold;">
				<p style="color:#FFFFFF;text-decoration:none;margin-top:0px;margin-bottom: 0px;">환율 계산기</p>
			</div> 
			<script type="text/javascript" src="https://w.fxexchangerate.com/converter.php?fm=KRW&ft=USD&lg=en&am=1&ty=1"></script>
		</div>

		<div>
			<button id="insertBtn" style=" width: 100%;">확인 </button>
		</div> 
	</div>
	
</div>


	    

	    <!-- /.row -->
	    
<script type="text/javascript">
    
    $(document).ready(function(){
    	
    	$("#ctySelectBtn").click(function(){
    		if($("#continent").val() == "대륙을 선택해주세요.") {
    			alert("검색할 대륙을 선택해주세요.");
    		} else if($("#countrys").val() == "나라를 선택해주세요.") {
    			alert("검색할 나라를 선택해주세요.");
    		}
    		
    	});
    	
    	//국가검색
    	$("#ctySelectBtn").click(function(){
    		
			for(i = 0; i <markersOnMap.length; i++) {
				if($("#countrys").val() == markersOnMap[i].CNT_CODE) {
					selectOption();	
				}
			}
    	});
    	
    	$("#ExchRonbtn").on('click',function(){
    		$("#infobtn").hide();
    		$("#ExchRontd").show();
    		$("#insertTo").html($("#fxexchangerateTo").val());
    	})
    	$("#ExchRonclosebtn").on('click',function(){
    		$("#infobtn").show();
    		$("#ExchRontd").hide();
    	})
    	$("#exchangebtn").on('click',function(){
    		$("#ExchangeRate").show();
    	})
    	$("#insertBtn").on('click',function(){
    		$("#ExchangeRate").hide();
    		$("#insertTo").html($("#fxexchangerateTo").val());
    	})
    	
    	
    	
    	// 내 여행 목록 추가 버튼
    	$("#addbtn").on('click', function(){   					
  			alert("추가");
  			addbtnsaveidx++;
  			var addhtml="";
  			addhtml += "<div id='add_div'>";
  			addhtml += "<input type='text' id='addtext' class='addtext' value='내 여행"+addbtnsaveidx+"'/>";
  			addhtml += "<button id='addbtnsave' class='btn btn-primary' onclick='addbtnsave("+addtextval+","+addbtnsaveidx+")'>저장</button>";
  			addhtml += "</div>";
  			
  			$("#addlist").append(addhtml);
  		 });
    	
    	
    	$("#back").click(function(){
    		$("#continent").val("none");
    		$("#countrys").val("none");
    		asds();
    	});
    	
        areaAllView();
        viewgrade(i);
        selectBox();
        asds();
    });


    var map, infowindow, zoom;
    var mapbtn			// map에 입력 될 마커 종류
    var InforObj = []; 
    var markers = [];
    var worldCenter = new google.maps.LatLng(39.09459, 179.24019);
    var json={};
    var marker_nat = new google.maps.Marker();
    var marker_ht = new google.maps.Marker();
    var CNTinfo = [];
    var markersOnMap = [];
    var latlng = []; 
    var CNTzoom = { minZoom: 2, maxZoom: 6 };
    
    
    
    function asds(){
    	mapbtn = "defaultMarkers";
    	map = new google.maps.Map(document.getElementById('map', CNTzoom), {
            zoom: 2,
            center: {
            	lat:37.57573,
            	lng:126.97683
            },
            gestureHandling: 'greedy'
        });
    	map.setOptions(CNTzoom);
        addMarkerInfo();
     	mainpost();
    };
    //추천여행지 이미지div불러오기
    
    
    
    
     function mainpost() {
    	
    	json={};
    	var data = getAjax("/main/getList.json", json)
    	
    	for(i=0 ; i<data.list.length ; i++){
    		
    		
    		html = "";
    		
    		html += "<a href='/lookup.do?seq="+data.list[i].PRV_SEQ+"'><img class='card-img-top' src='" + data.list[i].PRV_IMGFOLDER + data.list[i].PRV_IMG + "' width='208px', height='135px' alt=''></a>";
			html += "<div class='card-body'>";
			html += "<a href='/lookup.do?seq="+data.list[i].PRV_SEQ+"' style='color : black;'><h4 class='card-title'>" + data.list[i].PRV_TITLE + "</h4></a>";
            html += "</div><div class='card-footer'>";
            html += "<p class='card-text'>";
        	//html += "<div style='color : black;'>" + data.list[i].PRV_HASHTAG+"</div>";
            
        	console.log(json.rbseq);
        	json={};
        	json.rbseq = data.list[i].PRV_SEQ;
        	
         	var dataa = getAjax("/board/gettag.json", json)	//ajax
        	
          	for (var k = 0; k < dataa.list.length; k++) {
          		var urltag = encodeURI(dataa.list[k].TAGNAME, 'UTF-8');
        	   	html+= "<a href='/board_tag.do?tagname="+urltag+"' style='color : black;'> #" + dataa.list[k].TAGNAME + "</a>";
        	} 
            
            html += "</p> </div>";
          	$("#carddiv"+i).html(html);
    	}
    }
    
    
    
    
    var CNTCODE = [];
    var marker_nat, i;
    //marker
    function addMarkerInfo() {					// zoom level로 조정하면 function call이 너무 많아서 렉걸림
    	zoom = map.getZoom();
    
    	//국가 마크 불러오기
    	var data = getAjax("/CNTinfo.json",json);
			markersOnMap = data.CNTinfos
    	for(i = 0; i<markersOnMap.length; i++){
    		console.log(markersOnMap[i].CNT_CODE);
    		latlng[i] = [markersOnMap[i].CNT_LAT,markersOnMap[i].CNT_LNG];
    		
    		const marker_nat = new google.maps.Marker({	
    			placeName: markersOnMap[i].CNT_CODE,
                position: new google.maps.LatLng(latlng[i][0],latlng[i][1]),
                map: map,
                
                icon : new google.maps.MarkerImage("/resources/img"+markersOnMap[i].CNT_ICON_IMG+"", null, null, null, new google.maps.Size(32,32))
             });
    		
	           marker_nat.addListener('click', function () {
	    	        closeOtherInfo();
	    	        map.setCenter(marker_nat.getPosition());
	    	        map.setCenter(marker_nat.placeName);
	    	        //console.log(marker_nat.placeName);
					//console.log(markersOnMap);
	    	        alert(marker_nat.placeName+"국가 클릭");
	    	        initMap(marker_nat.placeName,marker_nat.getPosition());
	    	        json = {};
	    	        json.CODE = marker_nat.placeName;
	    	        data = getAjax("oneSelectBox.json", json);
	    	        $("#countrys").val(data.data.CNT_CODE).prop("selected", true);
	    	        $("#continent").val(data.data.CNT_CONTINENT).prop("selected", true);
	    	        if(mapbtn == "hotelMarkers"){
	    	            hotelMarker();
	    	        }else if(mapbtn == "taMarkers"){
	    	            
	    	        }else{
	    	        }
	    	        
	    	 	});//marker_nat.addListner
	            
	    	}	//nation marker for end
	        
	    } //addMarkerInfo end
    
	    
////국가 선택시 해당 국가의 관광지 정보     
  var locations = [];
  var addbtnsaveidx = 100;
  var mytriplist = [];
  var addtextval = null;
  var unlike = false;
  var CITYzoom = { minZoom: 7, maxZoom: 17 };
  function initMap(CNTCode,latlng) {
	  locations = [];
	  	//지도 스타일
	         map = new google.maps.Map(document.getElementById("map", CITYzoom), {
	      	 //처음 중심 좌표
	          center: latlng,
	          zoom: 12,
	          gestureHandling: 'greedy'
	        });
	         map.setOptions(CITYzoom);
	  	   var countryCode = CNTCode;
	    json.CTYCode = countryCode;
	    console.log("======="+json.CTYCode+"=======");
	         var data = getAjax("/insertInfo/Placemarker.json",json);
	         console.log("data1 == "+data.CTYCode);
	         console.log("data2 == "+data.marker);
	         CTYcode = data.CTYCode;
	         markers = data.marker;
	      
	         
	   for(var i = 0; i < CTYcode; i++){
	         		//console.log("data == "+markers[i].P_NAME);
	         		var pname = markers[i].P_NAME;
	         		
	           
	           locations[i] = [markers[i].P_LAT,markers[i].P_LNG];
	
	    	   };
	
	        
	        //마커 이미지
	        var customicon = 'http://drive.google.com/uc?export=view&id=1tZgPtboj4mwBYT6cZlcY36kYaQDR2bRM'
	
	        //인포윈도우
	        var infowindow = new google.maps.InfoWindow();
	
	        //마커 생성
	        var marker, i;
	        for (i = 0; i < locations.length; i++) {
	            marker = new google.maps.Marker({
	          	
	                //마커의 위치
	                position: new google.maps.LatLng(locations[i][0],locations[i][1]),
	 			 
	                //마커 아이콘
	                icon: customicon,
	                
	                //마커를 표시할 지도
	                map: map
	            });
	
	            google.maps.event.addListener(marker, 'click', (function(marker, i) {
	                return function() {
	              	  
	              	  json.recommpname = markers[i].P_NAME;
	               		console.log("data == " + json.recommpname);
	               	 	var data = getAjax("/insertInfo/Placerecomm.json",json);
// 	               	 	console.log(" == " + data.recommpname);
	               	 	//console.log(" == " + data.placeimg.IMG_NAME);
	               	 	var likeplace = data.recommpname;
	               	 	var placeimg = data.placeimg.IMG_NAME;
	               	 
	               	 	data = getAjax("/likePlace.json", json);  
	         	  		console.log(data);
	                  	//마커 정보
	                 	 if(data.recommpname == 1){
	                 		var likeBtn ="btn_unlike";
	                 	 }
	                    //html로 표시될 인포 윈도우의 내용
	                    var Placeinfo = "";
	         			Placeinfo += " <div class='wrap'>";
	 	           	Placeinfo += "	 <div class='text-box'>";
	 	           	Placeinfo += "		<button type='button' id='btn_like"+i+"' class='btn_like "+likeBtn+"' onclick='btn_like(this,"+i+")' value="+markers[i].P_NAME+" style='position: absolute; display: block; width: 44px; height: 44px; border: 1px solid #e8e8e8; border-radius: 44px; font-family: notokr-bold,sans-serif; font-size: 14px; line-height: 16px; background-color: #fff;  color: #DD5D54; box-shadow: 0 2px 2px 0 rgba(0,0,0,0.03);transition: border .2s ease-out,box-shadow .1s ease-out,background-color .4s ease-out; cursor: pointer;top: 0px;left: 0px;'>";
	 				Placeinfo += "			<span class='img_emoti'>좋아요</span>";
	 				Placeinfo += "		</button>";
	 	          	Placeinfo += " 		<h4>"+markers[i].P_NAME+"</h4>";
	 	            Placeinfo += "		<a target='_blank' href='#'>";
	 	           	Placeinfo += "		<div class='img-box'>";
	 	            Placeinfo += "			<img src='./img/"+placeimg+"'>"  ;
	 	            Placeinfo += "		</div>  ";
	 	           	Placeinfo += "			<p style='margin-bottom: 0px;'></p>";
	 	            Placeinfo += " 		</a>";
	 	            Placeinfo += "	</div>";
	
	                    infowindow.setContent(Placeinfo);
	                    
	                    //인포윈도우가 표시될 위치
	                    infowindow.open(map, marker);
	                    
	               
	              }
	                
	                
	            })(marker, i));
	     
	            if (marker) {
	                marker.addListener('click', function() {
	                    //중심 위치를 클릭된 마커의 위치로 변경
	                    map.setCenter(this.getPosition());
	 			  
	                    //마커 클릭 시의 줌 변화
	                    map.setZoom(16);
	                  
	                });
	            }
	        }
    }     
	    
  function btn_like(info, i){
	  
	  data = getAjax("/memberChk.json", json);
	  console.log(data.success);
	  if(data.success == "N") {
		  location.href = "/login.do";
	  } else {
	  
		 alert($(info).val());
		 unlike = false;
		 json.PNAME = $(info).val();
		 console.log("PNAME = " + json.PNAME);
			 
	   	  if($(info).hasClass('btn_unlike')){  
	   		json.RECOMM = "N";
	   		json.myTrip = "";
	   	    $(info).removeClass('btn_unlike');
	   	 	var data = getAjax("/insertInfo/recomm.json",json);
	   	    alert("저장취소");
	   	  }
	   	  else{
	   		  $("#element_to_pop_up").bPopup({
	   			  onOpen: function(e){
	   				$("#listname").html("");
	   				var data = getAjax("/insertInfo/mytrip.json",json);
	   				console.log(data.mytriplist);
	   				var mytriplist = data.mytriplist;
	   				for(i = 0; i<mytriplist.length; i++){
	   					console.log("내 여행 리스트"+mytriplist[i].MYRCM_LIST);
	   					addbtnsave(mytriplist[i].MYRCM_LIST,i);			
	   				}
	   			  },
	   			  onClose: function(){
	   				  if(unlike == true){
	   					$(info).addClass('btn_unlike');
	   				  }
		   		  }
	  		  });
	    }
	  }
	   	  
	 }
	 // 저장 버튼
	  function addbtnsave(list, idx){
		 console.log($('#addtext').val()+"저장");
		 console.log(list+"저장");
		 if( $('#addtext').val() != null){
			 list = $('#addtext').val();
			 console.log(list+"저장");
		 }
		 var listname = "";	
		 listname += "<div id='myTrip_div"+idx+"'>";
	     listname += "<input type='button' id='myTrip"+idx+"'class='myTrip' value='"+list+"' onclick='myTrip("+idx+")' onmouseover='mover("+idx+")' onmouseout='out("+idx+")' ></input>";
	     listname += "<input type='button' id='myTrip_del"+idx+"' class='myTrip_del' value='X' onclick='myTrip_del("+idx+")'></input>";
	     listname += "</div>";
		 $('#listname').append(listname);
		 $('#add_div').remove();
	 } 
	 
	 function myTrip(i){
		 if(confirm($('#myTrip'+i+'').val()+" 에 저장하시겠습니까 ?") == true){
			 json.myTrip = $('#myTrip'+i+'').val();
			 json.RECOMM = "Y";
		 	 json.addtext = $('#addtext').val();
		 	 var data = getAjax("/insertInfo/recomm.json",json); 
		     alert("저장");
		     unlike = true;
			 $("#b-close").trigger('click');
		 }
		 
	 }
	 function mover(i){
		 $('#myTrip'+i+'').css("background-color","#aaaaaa");
	 }
	 function out(i){
		 $('#myTrip'+i+'').css("background-color","#ffffff");
	 }
	 function myTrip_del(i){
		 alert($('#myTrip'+i+'').val() +"삭제");
		 json.myTripdel = $('#myTrip'+i+'').val();
		 var data = getAjax("/insertInfo/myTripdel.json",json);
		 $('#myTrip_div'+i+'').remove();
	 }
	    
	 
	 
	    
    
    function selectOption() {
    	marker_nat = new google.maps.Marker({
            position: new google.maps.LatLng(latlng[i][0],latlng[i][1])
        });
	        closeOtherInfo();
	        map.setZoom(8);
	        zoom = map.getZoom();
	        map.setCenter(marker_nat.getPosition());
	        alert("국가 검색");
	        if(mapbtn == "hotelMarkers"){
	            hotelMarker();
	        }else if(mapbtn == "taMarkers"){
	            
	        }
    }
    
    
    
    function hotelMarker(){
    	
    	zoom = map.getZoom();
    	
    	var data = getAjax("./project/selecthotelinfo.json", json)
		
        for (var i = 0; i < data.list.length; i++) {
            var contentString = '<div id="content"><h4>' + data.list[i].HOTELNAME_KOR +
                '</h4><p>'+data.list[i].HOTELLOCATION_LAT +' , '+data.list[i].HOTELLOCATION_LNG+'</p></div>';
                
			var myLatLng = new google.maps.LatLng(data.list[i].HOTELLOCATION_LAT, data.list[i].HOTELLOCATION_LNG);

            const marker_ht = new google.maps.Marker({
                position: myLatLng,
                map: map,
                icon : new google.maps.MarkerImage("/resources/img/emoji/hotel.png", null, null, null, new google.maps.Size(32,32))
            }); markers.push(marker_ht);

            const infowindow = new google.maps.InfoWindow({
                content: contentString,
                maxWidth: 200
            });
            
            marker_ht.addListener('click', function () {
                closeOtherInfo();
                infowindow.open(marker_ht.get('map'), marker_ht);
                InforObj[0] = infowindow;
            });
            
    	}
        
    } //end HotelMarker
    
    
    
    
	function TAMarker(){		// tourist Attraction
	
        
    } //end Tourist Attracion
    

    function closeOtherInfo() {
        if (InforObj.length > 0) {
            InforObj[0].set("marker", null);
            InforObj[0].close();
            InforObj.length = 0;
        }
    }

    $("#NTbtn").on("click", function(){		//국가
    	mapbtn = "defaultMarkers";
    	console.log(mapbtn);
    	addMarkerInfo();
    	
	});
    
    
    $("#HTbtn").on("click", function(){		//호텔
    	mapbtn = "hotelMarkers";
    	console.log(mapbtn);
    	addMarkerInfo();
    	
    	
    	
	});
    
    $("#TAbtn").on("click", function(){
    	mapbtn = "taMarkers";
    	console.log(mapbtn);
    	addMarkerInfo();
	});
    
    
    //추천여행지
 function areaAllView() {
	data = null;
	json = {};
	json.rownum = 5;
	data = getAjax("areaAllSelect.json", json);
	console.log(json);
	$("#bodyDiv").empty();
	var html="";
		for (i=0; i<4; i++) {
			html+= "<div class='col-lg-3 col-md-6 mb-4' name='ctyDiv' id='ctyBox"+i+"' data-toggle ='modal' data-target='#myModal' onclick='ctyModal("+i+")'>";
	        html+= "<img class='card-img-top' src='./img/"+ data.data[i].IMG_NAME +"' alt=''>";
	        html+= "<div class='card-body' style='color:black;padding: 0 0 0 0;margin-top: 10px;'>";
	        html+= "<h4 class='card-title' name='country' style='margin:0 0 0 0;'>"+ data.data[i].CTY_NAME+"("+data.data[i].AREA+")</h4>";
	        html+= "<p class='card-text' id='dName"+i+"'>"+ data.data[i].D_NAME +"</p>";
	        html+= "</div>";
	        html +="<div id='star"+i+"' name='starDiv' class='starRev' style='width:75%;margin-left:15%;'>";
	        for(j=0; j<5; j++) {
				html +="<span class='starR1' name='starR'>별1_왼쪽</span>";
				html +="<span class='starR2' name='starR'>별1_오른쪽</span>";
			}
	        html +="<h4 id='grade"+i+"' style='margin-left:2px; display: inline-block;'></h4>";
			html +="</div>";
	        html+= "</div>";
		}
	$("#bodyDiv").html(html);
	console.log(data);
}
    
	//국가 선택시 selectbox 자동선택
    function selectBox() {
    	json = {};
        data = getAjax("selectBox.json", json);
        console.log(data.data);
        var options = $('#continent').find('option').map(function() {
            return $(this).val();
      	}).get()
  		for(j=0; j<data.data.length; j++) {
        	$('#countrys').append("<option value='"+data.data[j].CNT_CODE+"'>"+data.data[j].CNT_NAME+"</option>'");
        }
    }
    
//국가검색
function chnQnaType(type , select) {
	
    $('#countrys').empty();
    if(type == '아시아') { // 아시아
    	$('#countrys').append("<option value='none' >나라를 선택해주세요.</option>'");
        $('#countrys').append("<option value='KR' >대한민국</option>'");
        $('#countrys').append("<option value='JP' >일본</option>'");
        $('#countrys').append("<option value='CN' >중국</option>'");
    } else if (type == '동남아시아') {  // 동남아시아
    	$('#countrys').append("<option value='none' >나라를 선택해주세요.</option>'");
        $('#countrys').append("<option value='TH' >태국</option>'");
        $('#countrys').append("<option value='VN' >베트남</option>'");
    } else if ( type == '유럽') {  // 유럽
    	$('#countrys').append("<option value='none' >나라를 선택해주세요.</option>'");
        $('#countrys').append("<option value='DE' >독일</option>'");
        $('#countrys').append("<option value='RU' >러시아</option>'");
        $('#countrys').append("<option value='BE' >벨기에</option>'");
        $('#countrys').append("<option value='GR' >그리스</option>'");
        $('#countrys').append("<option value='CH' >스위스</option>'");
        $('#countrys').append("<option value='ES' >스페인</option>'");
        $('#countrys').append("<option value='GB' >영국</option>'");
        $('#countrys').append("<option value='IT' >이탈리아</option>'");
        $('#countrys').append("<option value='FR' >프랑스</option>'");
    } else if (type == '북아메리카') {  // 북아메리카
    	$('#countrys').append("<option value='none' >나라를 선택해주세요.</option>'");
        $('#countrys').append("<option value='US' >미국</option>'");
    }
}

//모달
function ctyModal(i) {
		$("#insertModal").empty();
		$("#myModalLabel").html($("#dName"+i+"").html());
		json.D_NAME = $("#dName"+i+"").html();
		data = getAjax("areaInfo.json", json);
		var html="";
		html+="<div class='card shadow mb-4' style='width:100%;'>";
		html+="<div class='card-header py-3' style='display:flex;'>";
		html+= "<ul class='imgUl'>"
		for(i=0; i<data.data.length; i++) {
		    html+= "<li class='imgLi'>"
		    	html+= "<img class='card-img-top' style='height:10vw;' src='./img/"+ data.data[i].IMG_NAME +"' alt=''>";
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
	
		$("#insertModal").html(html);
}
	
	//평점 조회
    function viewgrade(i) {
    	json = {};
    	for(j=0; j<i; j++) {
    	json.PLACE = $("#dName"+j+"").html();
    	data = getAjax("viewgrade.json", json);
	    	if(data.data == null) {
	    		$("#grade"+j+"").text("");
	    	} else {
		    	var round = parseFloat(data.data.ROUND)*2;
		    	rounds = round - Math.floor(round);
		    	if(Math.round(rounds*100)/10.0 > 0.5) {
		    		round = Math.floor(parseFloat(data.data.ROUND)*2);
		    	}
			    	for(k=0; k<round; k++) {
			    		$("#star"+j+" span").eq(k).addClass( 'on' );
			    		$("#grade"+j+"").text(data.data.ROUND);
		    		}
	    	}
    	
    	}
    }
    
	
    </script>
    
<body>
    <div id="element_to_pop_up">
   		<a id="b-close" class="b-close">x</a>
   		<div>내 여행 </div>
   		<hr>
   		<div id="listname">
   
   		</div>
   		<div id="addlist">
   		
  		</div>
   		<button id="addbtn" class="addbtn" style="margin-left: 40%; margin-top: 10px;">+</button>
	</div>
</body>

