<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<style>


	#floating-panel {
        position: absolute;
        top: 10px;
        left: 15%;
        z-index: 5;
        background-color: #fff;
        padding: 5px;
        border: 1px solid #999;
        text-align: center;
        font-family: 'Roboto','sans-serif';
        line-height: 30px;
        padding-left: 10px;
      }

      
      #map {
        float: center;
        width: 100%;
        height: 600px;
      }
      table { 
			width : 100%;
			margin : auto;
			text-align: center;
	}
	
	#board td {
			border: 1px solid #bcbcbc;
	}
	
	tr {
	 		height : 30px;
			margin : auto;
			vertical-align: center;
	}
			
	td {
			text-align:center; 
			margin : auto;
			vertical-align: center;
	}
	th {
			font-weight : bold;
			text-align : center;
			margin : auto;
			vertical-align: center;
	}
</style>
<br>
<br>
<br>
	<div id="tablediv">
		<table width="100%" id="table">
	          <tr>
	          	<th colspan='2'>새로운 호텔 정보 입력</th><th colspan='2'>호텔 정보 수정</th><th colspan='2'>호텔 정보 삭제</th>
	          </tr>
	          
	          <tr>
	          	<th>호텔명(영어)</th>
	          	<td><input type="text" id='addhotelNameEng' autocomplete="off"></td>
	          	<th>호텔명(영어)</th>
	          	<td><input type="text" id='addhotelNameEng_modify' autocomplete="off"></td>
	          </tr>
	          
	          <tr>
	          	<th>호텔명(한국어)</th>
	          	<td><input type="text" id='addhotelNameKor' autocomplete="off"></td>
	          	<th>호텔명(한국어)</th>
	          	<td><input type="text" id='addhotelNameKor_modify' autocomplete="off"></td>
	          	<th>Hotel SEQ</th>
	          </tr>
	          
	          <tr>
	          	<th>국가명(영어)</th>
	          	<td><input type="text" id='addhotelNatNameEng' autocomplete="off"></td>
	          	<th>국가명(영어)</th>
	          	<td><input type="text" id='addhotelNatNameEng_modify' autocomplete="off"></td>
	          	<td><input type="text" id='hotelSeqDelete' autocomplete="off"></td>
	          </tr>
	          
	          <tr>
	          	<th>국가명(한국어)</th>
	          	<td><input type="text" id='addhotelNatNameKor' autocomplete="off"></td>
	          	<th>국가명(한국어)</th>
	          	<td><input type="text" id='addhotelNatNameKor_modify' autocomplete="off"></td>
	          </tr>
	          
	          <tr>
	          	<th>도시명(영어)</th>
	          	<td><input type="text" id='addhotelCityNameEng' autocomplete="off"></td>
	          	<th>도시명(영어)</th>
	          	<td><input type="text" id='addhotelCityNameEng_modify' autocomplete="off"></td>
	          </tr>
	          
	          <tr>
	          	<th>도시명(한국어)</th>
	          	<td><input type="text" id='addhotelCityNameKor' autocomplete="off"></td>
	          	<th>도시명(한국어)</th>
	          	<td><input type="text" id='addhotelCityNameKor_modify' autocomplete="off"></td>
	          </tr>
	          
	          <tr>
	          	<th>좌표 LAT(위도)</th>
	          	<td><input type="text" id='addhotelLocation_Lat' autocomplete="off"></td>
	          	<th>좌표 LAT(위도)</th>
	          	<td><input type="text" id='addhotelLocation_Lat_modify' autocomplete="off"></td>
	          </tr>
	          <tr>
	          	<th>좌표 LNG(경도)</th>
	          	<td><input type="text" id='addhotelLocation_Lng' autocomplete="off"></td>
	          	<th>좌표 LNG(경도)</th>
	          	<td><input type="text" id='addhotelLocation_Lng_modify' autocomplete="off"></td>
	          </tr>
	          <tr>
	          	<th cospan='2'><td></td></th>
	          	<th>HOTEL SEQ</th>
	          	<td><input type="text" id='hotelSeq_modify' autocomplete="off"></td>
	          </tr>
	          <tr>
	          <th colspan='2'><input type='button' id='addhotelBtn' value="입력"></th>
	          <th colspan='2'><input type='button' id='modifyhotelBtn' value="수정"></th>
	          <th><input type='button' id='deletehotelBtn' value="삭제"></th>
	          </tr>
	    </table>
    </div>
    
    <div id="map">
    </div>
    
    

	<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBM3YAiv6ptli8_XfGpVyb6Koy0Ivjxl2Q&region=kr"></script> 

    
    
    <script type="text/javascript">
    var map;
    var InforObj = [];
    var testCenter = new google.maps.LatLng(36.791460, 127.920225);
    var json={};
    var markersOnMap;
    
    $(document).ready(function(){
    	
    	var geocoder = new google.maps.Geocoder;
		var lat = "";
		var lng = "";  
		    	
    	$("#addhotelBtn").on("click", function(){
    		var addhotelNameEng = $("#addhotelNameEng").val();
    		var addhotelNameKor = $("#addhotelNameKor").val();
    		var addhotelNatNameEng = $("#addhotelNatNameEng").val();
    		var addhotelNatNameKor = $("#addhotelNatNameKor").val();
    		var addhotelCityNameEng = $("#addhotelCityNameEng").val();
    		var addhotelCityNameKor = $("#addhotelCityNameKor").val();
    		var addhotelLocation_Lat = $("#addhotelLocation_Lat").val();
    		var addhotelLocation_Lng = $("#addhotelLocation_Lng").val();
    		
    		json.addhotelNameEng = addhotelNameEng;
    		json.addhotelNameKor = addhotelNameKor;
    		json.addhotelNatNameEng = addhotelNatNameEng ;
    		json.addhotelNatNameKor = addhotelNatNameKor ;
    		json.addhotelCityNameEng = addhotelCityNameEng;
    		json.addhotelCityNameKor = addhotelCityNameKor;
    		json.addhotelLocation_Lat = addhotelLocation_Lat;
    		json.addhotelLocation_Lng = addhotelLocation_Lng;
    		
    		var data = getAjax("project/addhotelinfo.json", json)
    		
    		if(data.addInfo == true){
    			alert("호텔 정보 등록 완료.");
    			location.href = "./adminInserthotel.do";
    		}else{
    			alert("등록 실패");
    			return false;
    		}
    	});
    	
    	
    	
    	$("#modifyhotelBtn").on("click", function(){
    		var addhotelNameEng_modify = $("#addhotelNameEng_modify").val();
    		var addhotelNameKor_modify = $("#addhotelNameKor_modify").val();
    		var addhotelNatNameEng_modify = $("#addhotelNatNameEng_modify").val();
    		var addhotelNatNameKor_modify = $("#addhotelNatNameKor_modify").val();
    		var addhotelCityNameEng_modify = $("#addhotelCityNameEng_modify").val();
    		var addhotelCityNameKor_modify = $("#addhotelCityNameKor_modify").val();
    		var addhotelLocation_Lat_modify = $("#addhotelLocation_Lat_modify").val();
    		var addhotelLocation_Lng_modify = $("#addhotelLocation_Lng_modify").val();
    		var hotelSeq_modify = $("#hotelSeq_modify").val();
    		
    		if(confirm("호텔 SEQ "+ hotelSeq_modify +" 을/를 정말 수정하시겠습니까?")){
    			
    			json.addhotelNameEng_modify = addhotelNameEng_modify;
        		json.addhotelNameKor_modify = addhotelNameKor_modify;
        		json.addhotelNatNameEng_modify = addhotelNatNameEng_modify ;
        		json.addhotelNatNameKor_modify = addhotelNatNameKor_modify ;
        		json.addhotelCityNameEng_modify = addhotelCityNameEng_modify;
        		json.addhotelCityNameKor_modify = addhotelCityNameKor_modify;
        		json.addhotelLocation_Lat_modify = addhotelLocation_Lat_modify;
        		json.addhotelLocation_Lng_modify = addhotelLocation_Lng_modify;
        		json.hotelSeq_modify = hotelSeq_modify;
        		
        		var data = getAjax("/project/modifyhotelinfo.json", json)
        		
        		if(data.modifyInfo == true){
        			alert("호텔 정보 수정 완료.");
        			location.href = "./adminInserthotel.do";
        		}else{
        			alert("수정 실패");
        			return false;
        		}
    		}else{}	
    	});
    	
 
    	
    	
    	
    	$("#deletehotelBtn").on("click", function(){
    		var hotelSeqDelete = $("#hotelSeqDelete").val();
    		
    		if(confirm("호텔 SEQ "+ hotelSeqDelete +" 을/를 정말 삭제하시겠습니까?")){
    			json.hotelSeqDelete = hotelSeqDelete;
        		var data = getAjax("./deletehotelinfo.json", json)
        		
        		if(data.deletehotelinfo == true){
        			alert("호텔 정보 삭제 완료.");
        			location.href="./adminInserthotel.do";
        		}else{
        			alert("등록실패");
        			return false;
        		}
    		}else{}
    		
    		
    	});
    	
    	initMap();
    	
    	
 	 	 map.addListener('click', function(e){
 	 		 console.log(e.latLng);
 			
 				// 위경도 좌표를 요창할 객체를 만들어 줍니다.
 	    	    var latlng = {
 	    	       lat: e.latLng.lat(),
 	    	    	lng: e.latLng.lng()
 	    	    };
 	            geocoder.geocode({'location': latlng}, function(results, status) {

 	                if( status === "OK" )
 	                {                  	
 	                  	lat = latlng.lat;
 	             		lng = latlng.lng;
 		
 	                 	console.log(lat.toFixed(5));
 	                 	console.log(lng.toFixed(5));
 	                 	
 	                }else{
 	                  alert("주소를 못 가지고 왔습니다. 사람 사는 곳이 아닌 것 같습니다.");
 	                }
 	                $("#addhotelLocation_Lat").val(lat.toFixed(5));
 	                $("#addhotelLocation_Lng").val(lng.toFixed(5));

 	              });
 	     	  });		
    	
    	
    	function addMarkerInfo() {
    		
    		var data = getAjax("project/selecthotelinfo.json", json)
			
			console.log(data);
    		var listArray = data.list;
    		
            for (var i = 0; i < data.list.length; i++) {
                var contentString = '<div id="content"><h2>HOTEL_SEQ : ' + data.list[i].HOTEL_SEQ +
                    '</h2><p>'+data.list[i].HOTELNAME_KOR+'</p><p>'+data.list[i].HOTELLOCATION_LAT +' , '+data.list[i].HOTELLOCATION_LNG +'</p></div>';
                    
				var myLatLng = new google.maps.LatLng(data.list[i].HOTELLOCATION_LAT, data.list[i].HOTELLOCATION_LNG);
				
				console.log(myLatLng);
                const marker = new google.maps.Marker({
                    position: myLatLng,
                    map: map,
                    icon : new google.maps.MarkerImage("/resources/img/emoji/hotel.png", null, null, null, new google.maps.Size(32,32))
                });

                const infowindow = new google.maps.InfoWindow({
                    content: contentString,
                    maxWidth: 200
                });

                marker.addListener('click', function () {
                    closeOtherInfo();
                    infowindow.open(marker.get('map'), marker);
                    InforObj[0] = infowindow;
                });
            }
        }

      	function closeOtherInfo() {
    		if (InforObj.length > 0) {
    	    	InforObj[0].set("marker", null);
    	        InforObj[0].close();
    	        InforObj.length = 0;
	        }
		}
    	    
    	    

    	function initMap() {
    	        map = new google.maps.Map(document.getElementById('map'), {
    	            zoom: 7,
    	            center: testCenter
    	        });
    	        addMarkerInfo();
    	    }    
    	    
   });// end documentready
    

   
    </script>
