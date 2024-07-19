<%@ page language="java" contentType="text/html; charset=EUC-KR" pageEncoding="EUC-KR"%>


    <script src="https://polyfill.io/v3/polyfill.min.js?features=default"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCCGMSf2mPOt_0r0ms4jQP1kRfVc18E1-A&callback=initMap&libraries=&v=weekly&region=kr" defer></script>

    <script src="../../resources/js/common/bPopup.js?ver=1.0" type="text/javascript"></script>
    
    <style type="text/css">
    
      /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
      #map {
        height: 700px;
      }

      /* Optional: Makes the sample page fill the window. */
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
        h4 {
            margin: 10px auto 0;
        }
        div.img-box {
            max-height: 100px;
            overflow: hidden;
        }
        img {
            width: 150px;
            margin: -20px auto 0;
        }
        a {
            text-decoration: none;
            color: #000;
        }
        
        
        /* 확대/축소 등 구글 지도의 기본 UI 감추기 */
        .gmnoprint, .gm-control-active.gm-fullscreen-control {
            display: none;
        }
        ///////////////////////////////////////////////////////////////
		.btn_like {
			  position: relative;
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
			font-size:25px;
			padding:1px 8px;
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
		.addbtnsave {
			box-shadow:inset 0px 1px 0px 0px #ffffff;
			background:linear-gradient(to bottom, #f9f9f9 5%, #e9e9e9 100%);
			background-color:#f9f9f9;
			border-radius:6px;
			border:1px solid #dcdcdc;
			display:inline-block;
			cursor:pointer;
			color:#666666;
			font-family:Arial;
			font-size:13px;
			font-weight:bold;
			padding:3px 1px;
			text-decoration:none;
			text-shadow:0px 1px 0px #ffffff;
		}
		.addbtnsave:hover {
			background:linear-gradient(to bottom, #e9e9e9 5%, #f9f9f9 100%);
			background-color:#e9e9e9;
		}
		.addbtnsave:active {
			position:relative;
			top:1px;
		}
		
		
 /////////////////////////////////////////////////////////////////////       
    </style>
    <script>   
     ;(function($) {
      // DOM Ready
     $(function() {
         // Binding a click event
         // From jQuery v.1.7.0 use .on() instead of .bind()
         $('#my-button').bind('click', function(e) {
             // Prevents the default action to be triggered. 
             e.preventDefault();
             // Triggering bPopup when click event is fired
             $('#element_to_pop_up').bPopup();
         });
     });
 })(jQuery);

    </script> 
    <script>
    var json = {};
    var locations = [];
    var addbtnsaveidx = 100;
    var mytriplist = [];
    var addtextval = null;
    var unlike = false;
      $(document).ready(function(){
    	  
    	  var geocoder = new google.maps.Geocoder;
    	  var results = [];
		  var type = "";
		  var lat = "";
		  var lng = "";
		  var compoundcode = "";
		  var globalcode = "";
		  var cityName = "";
		  
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
                 	for(var i = 0; i < results.length ; i++){
                 		var lastresults = results[i];
                     }
                 	
                 	var types = results[0].types;
                 	var pluscode = results[0].plus_code;
                 	
                 	lat = latlng.lat;
            		lng = latlng.lng;
            		
                 	var type = "";
                 	for(var i = 0; i < types.length ; i++){
                 		type += "@";
                 		type += types[i];
                 	}
                 	console.log(type);
                	console.log(lastresults);
                	console.log(lastresults.address_components[0].long_name);
                	console.log(lastresults.address_components[0].short_name);
                	console.log(results[0]);
                	console.log(types);	
                	console.log(pluscode);	
                	console.log(lat.toFixed(5));
                	console.log(lng.toFixed(5));
                	
                	juso = results[0].formatted_address;
                	country = lastresults.address_components[0].long_name
                	countryCode = lastresults.address_components[0].short_name;
                	compoundcode = pluscode.compound_code;
                	globalcode = pluscode.global_code;

                	cityName = results[0].address_components[3].long_name;
                 	
               }else{
                 alert("주소를 못 가지고 왔습니다. 사람 사는 곳이 아닌 것 같습니다.");
               }
               $("#Placeinfo_Lat").val(lat.toFixed(5));
               $("#Placeinfo_Lng").val(lng.toFixed(5));
               $("#Placeinfo_juso").val(juso);
               $("#Placeinfo_types").val(type);
               $("#Placeinfo_country").val(country);
               $("#Placeinfo_countryCode").val(countryCode);	
               $("#Placeinfo_compound_code").val(compoundcode);	
               $("#Placeinfo_global_code").val(globalcode);	
               $("#Placeinfo_name").val("");	
               $("#Placeinfo_city").val(cityName);	

             });
    	  });
    	  
    	  //저장버튼을 클릭했을 경우
    	  $("#insertinfobtn").on("click", function(){
    		  if($("#Placeinfo_country").val() == ""){
    			  alert("위치를 클릭하세요");
    		  }else if($("#Placeinfo_name").val() == ""){
    			  alert("장소이름을 입력하세요");
    			  $("#Placeinfo_name").focus();
    		  }else{
    			  
   			
				//지도좌표정보 저장
	   			json.CTY           =   $("#Placeinfo_country").val();
	   			json.CTY_CODE      =   $("#Placeinfo_countryCode").val();	
	   			json.NAME          =   $("#Placeinfo_name").val();	                         
	   			json.TYPES         =   $("#Placeinfo_types").val();   
	   			json.JUSO          =   $("#Placeinfo_juso").val();   
	   			json.LAT           =   $("#Placeinfo_Lat").val();
	   			json.LNG           =   $("#Placeinfo_Lng").val();
	   			json.COMPOUND_CODE =   $("#Placeinfo_compound_code").val();
	   			json.GLOBAL_CODE   =   $("#Placeinfo_global_code").val();
	   			
	   			console.log(json);
	   			var data = getAjax("/insertInfo/insertinfo.json",json);
	   			
	   			if(data.success=='Y'){
					alert("좌표등록 성공");
					
	 				var place_name = $("#Placeinfo_name").val();
					var img_content = $("#Placeinfo_content").val();
					var img_contry_code = $("#Placeinfo_countryCode").val();	
					var img_city = $("#Placeinfo_city").val();
					var img_contry = $("#Placeinfo_country").val();
					
					
			
					var formData = new FormData();
					var inputFile = $("input[name='Placeinfo_img']");
					
					console.log(inputFile);

	 				var files = [];
					
					for(i=0; i<inputFile.length; i++){
						files[i] = inputFile[i].files[0];
						formData.append("uploadFile", files[i]);
					} 
					
					formData.append("place_name", place_name);
	 				formData.append("img_content", img_content);
					formData.append("img_contry_code", img_contry_code);
					formData.append("img_city", img_city); 
					formData.append("img_contry", img_contry);
					
					console.log(files);

					var  token = $("meta[name='_csrf']").attr("content");
					var  header = $("meta[name='_csrf_header']").attr("content");
					
					var imgData= null;
					
					$.ajax({
						url : "./insertAreaInfo.json",
						processData : false,
						contentType : false,
						data : formData,
						async:false,
						type : 'POST',
				        beforeSend: function(xhr) {
				            xhr.setRequestHeader(header, token);
				        },
						success : function(data) {
							imgData=data;
							

						}, error : function(jqXHR, textStatus, errorThrown) {
							console.log(jqXHR.responseText);
						}
					});	
					if (imgData.success=='Y'){
						alert("여행지 정보갱신에 성공했습니다.");
						location.reload();
					} else{
						alert("정보갱신에 실패했습니다.");
					}
	   			} else {
	   				alert("좌표저장중 오류가 발생했습니다.")
	   			}
    		  }
    	  });
    	  $("#addbtn").on('click', function(){   					
  			alert("추가");
  			addbtnsaveidx++;
  			var addhtml="";
  			addhtml += "<div id='add_div'>";
  			addhtml += "<input type='text' id='addtext' class='addtext' value='내 여행"+addbtnsaveidx+"'/>";
  			addhtml += "<button id='addbtnsave' class='addbtnsave' onclick='addbtnsave("+addtextval+","+addbtnsaveidx+")'>저장</button>";
  			addhtml += "</div>";
  			
  			$("#addlist").append(addhtml);
  		 });
      });

      function initMap(countryCode) {

    	//지도 스타일
           map = new google.maps.Map(document.getElementById("map"), {
        	 //처음 중심 좌표
            center: {
              lat: 37.57207,
              lng: 127.00135
            },
            zoom: 12
          });
    	   var countryCode = "KR";
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
                	  
//            	  json.recommpname = markers[i].P_NAME;
//             		console.log("data == " + json.recommpname);
//             	 	var data = getAjax("/insertInfo/Placerecomm.json",json);
//             	 	console.log(" == " + data.recommpname);
//             	 	console.log(data);
//             	 	var likeplace = data.recommpname;
//  	         	 //마커 정보
//  	         	 if(likeplace == 1){
//  	        	 	var likeBtn ="btn_unlike";
//  	          	 } 
                	  	
  						var jsonp={};
  						jsonp.D_NAME = markers[i].P_NAME;
						data = getAjax("areaInfo.json", jsonp);
  
                      //html로 표시될 인포 윈도우의 내용
                      var Placeinfo = "";
	          			Placeinfo += " <div class='wrap'>";
			           	Placeinfo += "	 <div class='text-box'>";
//			           	Placeinfo += "		<button type='button' id='btn_like"+i+"' class='btn_like "+likeBtn+"' onclick='btn_like(this,"+i+")' value="+markers[i].P_NAME+" style='position: relative; display: block; width: 44px; height: 44px; border: 1px solid #e8e8e8; border-radius: 44px; font-family: notokr-bold,sans-serif; font-size: 14px; line-height: 16px; background-color: #fff;  color: #DD5D54; box-shadow: 0 2px 2px 0 rgba(0,0,0,0.03);transition: border .2s ease-out,box-shadow .1s ease-out,background-color .4s ease-out; cursor: pointer;'>";
//						Placeinfo += "			<span class='img_emoti'>좋아요</span>";
//						Placeinfo += "		</button>";
			          	Placeinfo += " 		<h4>"+markers[i].P_NAME+"</h4>";
			           	Placeinfo += "		<div class='img-box'>";
		    			Placeinfo+= "<img class='place-img' style='height:10vw;' src='./img/"+ data.data[0].IMG_NAME +"' alt=''>";
			            Placeinfo += "		</div>  ";
			            Placeinfo += "		<button class='deletePlaceInfo' value="+markers[i].P_NAME+" onclick='deletePlaceInfo(this)'>삭제</button>";
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
 
 //삭제버튼 클릭시 관광지 정보 삭제
function deletePlaceInfo(info){
	 if(confirm("정말로 삭제하시겠습니까?")==true){
		 alert("1");
		 var jsond={};
		 jsond.name=$(info).val();
		 console.log(jsond);
		 var data=getAjax("./deletePlaceInfo.json",jsond);
		 location.reload();
	 }
 }
 
  function addbtnsave(list, idx){
	 console.log($('#addtext').val()+"저장");
	 console.log(list+"저장");
	 if( $('#addtext').val() != null){
		 list = $('#addtext').val();
		 console.log(list+"저장");
	 }
	 var listname = "";	
	 listname += "<div id='myTrip_div"+idx+"'>";
     listname += "<input type='button' id='myTrip"+idx+"' value='"+list+"' onclick='myTrip("+idx+")' onmouseover='mover("+idx+")' onmouseout='out("+idx+")'  style='width: 90%;background-color: white;'></input>";
     listname += "<input type='button' id='myTrip_del"+idx+"' value='X' onclick='myTrip_del("+idx+")' style='width: 10%;background-color: white;border-left-width: 0px;padding-top: 3px;padding-right: 12px;padding-left: 5px;'></input>";
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

    </script> 


  	<div id="tablediv">
		<table width="100%" id="table">
	    	<sec:authorize access="hasAnyRole('ROLE_MEMBER','ROLE_ADMIN')">
				<sec:authentication property="principal.username" var="user_id" />				
				<div id="user_id" style="color:white;">안녕하세요. ${user_id }님</div>               
			</sec:authorize>
	          <tr>
	          	<th>주소</th>
	          	<td colspan= "3"><input type="text" id='Placeinfo_juso' style="width: 500px;"></input></td>	
	          </tr>
	          <tr>
	          	<th>타입</th>
	          	<td colspan= "3"><input type="text" id='Placeinfo_types' style="width: 500px;"></input></td>	
	          </tr>
	          <tr>
	          	<th>좌표 LAT(위도)</th>
	          	<td><input type="text" id='Placeinfo_Lat'></input></td>
	          	<th>국가</th>
	          	<td><input type="text" id='Placeinfo_country'></input></td>
	          </tr>
	          <tr>
	          	<th>좌표 LNG(경도)</th>
	          	<td><input type="text" id='Placeinfo_Lng'></input></td>	
	          	<th>국가 코드</th>
	          	<td><input type="text" id='Placeinfo_countryCode'></input></td>	
	          </tr>
	          <tr>
	          	<th>compound 코드</th>
	          	<td><input type="text" id='Placeinfo_compound_code'></input></td>
	          	<th>글로벌 코드</th>
	          	<td><input type="text" id='Placeinfo_global_code'></input></td>	
	          </tr>
	          <tr>
	          	<th>장소 이름</th>
	          	<td><input type="text" id='Placeinfo_name'></input></td>
	          	<th>도시명</th>
	          	<td><input type="text" id='Placeinfo_city'></input></td>	
	          </tr>
	          <tr>
	          	<th>이미지</th>
	          	<td><input type="file" name="Placeinfo_img"></td>
	          	<td><input type="file" name="Placeinfo_img"></td>
	          	<td><input type="file" name="Placeinfo_img"></td>
	          </tr>
	          <tr>
	          	<th>상세설명</th>
	          	<td colspan= "3"><input type="text" id="Placeinfo_content" style="width: 500px;"></td>
	          </tr>
	          <tr>
	          <th></th>
	          	<td><input type="button" id="insertinfobtn" value="저장"></input></td>
	          </tr>
	    </table>
    </div>
  <!-- Button that triggers the popup -->
<button id="my-button">POP IT UP</button>
<!-- Element to pop up -->
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

    
    <div id="map"></div>


