<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib prefix="sec"
	uri="http://www.springframework.org/security/tags"%>

<style>

.map {
		margin-top: 0px;
        z-index : 4;
        position : relative;

      }
* {
	margin: 0;
	padding: 0;
}
 .gmnoprint, .gm-control-active.gm-fullscreen-control {
            display: none;
  }


	ul,li{list-style:none;}
  .slide{width:100%;height:500px;overflow:hidden;position:relative;text-align:center;}
  .slide ul{width:calc(100% * 8);display:flex;transition:1s;}
  .slide li{width:calc(100% / 8);height:500px;}
  


  .slide input{/*display:none;*/}
  .slide .bullet{position:absolute;bottom:20px;left:0;right:0;text-align:center;z-index:10;}
  .slide .bullet label{width:50px;height:20px;border-radius:10px;border:2px solid #666;display:inline-block;background:#fff;font-size:10px;transition:0.5s;cursor:pointer;}
  
	/* 슬라이드 조작 */
	#pos1:checked ~ ul {margin-left: 0;}
 	#pos2:checked ~ ul {margin-left: -100%;}
	#pos3:checked ~ ul {margin-left: -200%;}
	#pos4:checked ~ ul {margin-left: -300%;}
	#pos5:checked ~ ul {margin-left: -400%;}
	#pos6:checked ~ ul {margin-left: -500%;}
	#pos7:checked ~ ul {margin-left: -600%;}
	#pos8:checked ~ ul {margin-left: -700%;}

	 

	
	/* bullet 조작 */
	#pos1:checked ~ .bullet label:nth-child(1), #pos2:checked ~ .bullet label:nth-child(2),
	#pos3:checked ~ .bullet label:nth-child(3), #pos4:checked ~ .bullet label:nth-child(4),
	#pos3:checked ~ .bullet label:nth-child(5), #pos4:checked ~ .bullet label:nth-child(6),
	#pos3:checked ~ .bullet label:nth-child(7), #pos4:checked ~ .bullet label:nth-child(8){background: #666;}

/*구글맵*/
	
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
      
      #right-panel {
        font-family: 'Roboto','sans-serif';
        line-height: 30px;
        position : relative;
      }


      #right-panel i {
        font-size: 10px;
      }
      #right-panel {
        float: right;
        overflow: auto;
        width : 15%;
        height: 100%;
        background-color:aliceblue;
        border: 1px solid black;
    	border-radius: 10px;
      }



</style>


<!-- Navigation -->

<!-- Page Content -->
<div class="container">
	<header class="jumbotron my-4">
		<div id="aaa">
			<h2 style="padding-top: 20px;">게시글</h2>
		</div>
	</header>

	<div id="slidediv" class="slide" style="height: 524px; width:100%;">
			<input type="radio" name="pos" id="pos1" value="1일차" checked>
			<ul id="add" style="height: 500px;">
				<li style="height: 500px;">
					<div class="mapinfo">
					</div>
	
					<div id="right-panel" >
						<div>
							<input type="button" id="addradiobtn" class='btn btn-primary' onclick="addradiobtn()"value="+"/>
						</div>
						<hr width="100%">
						<div>
							<p id="newRoute" > $경로 만들기$ (새창)</p>
						</div>
						<div id="bookmark_div">
							<b>북마크 :</b>
							<select id="bookmark1" name="bookmark" onchange="bookmarkinfo(1);">
								<option selected>리스트를 선택해주세요.</option>
							</select>
						</div>
					</div>
					<div class='map' id="map1" style="height:500px; width:85%"></div>	
				</li>
			</ul>
				</div>
	
	</div>



	<!-- Page Features -->
	<div class="form-group" style="margin-top: 2rem;">
		<label>번호</label> <font class="text-gray-900" id="boardseq"></font>
		<div class="form-group" style="float: right;">
			<label>작성자</label> <font class="text-gray-900" id="boardWriter">
			</font>
		</div>
	</div>
	
	<div id="tripList_div">
		<b>내 여행:</b>
		<select id="tripList" name="tripList" onchange="SetSelectBox();">
				<option selected>리스트를 선택해주세요.</option>
		</select>
	</div>
	<br>
	

	<div>
		<label style="width: 15vw;">제목</label> <input type="text"
			id="sumPlace">
	</div>
	<div>
		<label style="width: 15vw;">태그</label> <input type="text" id="sumTag"
			placeholder="#로 태그를 구분해주세요">
	</div>
	
	<div class="uploadDiv" style="">

		<input type="file" name='uploadFile' id="uploadFile"
			accept=".gif, .jpg, .png">
	</div>
	<div>썸네일 이미지</div>
	
	<div class="previewDownload"></div>
	<div class="downloadFileName"></div>
	<div class="preview"></div>
	<div class="previewFileName"></div>
	
	<div>
		
	</div>
	<div id="review_div"></div>

	<div>
		<button type='button' id="allsavebtn" class='btn btn-primary'>전체저장</button>
	</div>
</div>
<!-- /.Page Content -->
<meta charset="utf-8">
 <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBM3YAiv6ptli8_XfGpVyb6Koy0Ivjxl2Q&libraries=places&region=kr"
         ></script>
<script src="../../resources/js/common/common.js?ver=1.1"
	type="text/javascript"></script>
<script type="text/javascript">
var boardseq = "";
var json = {};
var json1 = {};
var insertTitle   ="";
var insertContent ="";
var RCM = [];
var reviewbno = new Array();
var userId=null;
var isAdmin=null;
var reviewimg = [];
var reviewPlace =[];
var rcmplace = [];
var allrcmplace = [];
var rai;
var boardseq;
var rai;
var page_no=1;


//--------------------

var place, places, map, infowindow, myLatLng, markers_mk, marker1,mymarker , wp;
	var mylat, mylng, curlat, curlng, currentpos;
	var DepartPosition, ArrivePosition, input, searchBox, selectbox, currentpos, contentString, contentString2;
	var addmap = [];
	var markers=[];
	var markers2=[];
	var InforObj = [];
	var map = new google.maps.Map(document.getElementById('map1'), {
    	center: {lat: 37.56697, lng: 126.97842},
    	zoom: 3,
    	mapTypeId: 'roadmap',
    	gestureHandling: 'greedy'
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

	var arr = [];
	var ttrday =1;
	var maps = [];
	var $maps = $('.map');
	var mapDivId;
	var DeparArr =[];
	var ArrveArr = [];
	var userId;
	var WaypoArr = [];


$(document).ready(function(){
	console.log(ttrday);
	
	$maps = $('.map');
	$.each($maps, function (i, value) {
        
		
        mapDivId = $(value).attr('id');

        maps[mapDivId] = new google.maps.Map(document.getElementById(mapDivId), {
            zoom: 15,
            center: {lat: 35.1379222, lng:129.05562775}
        });
            
        arr.push(maps[mapDivId]);
        
    })
    
	userId="${userId}"
	isAdmin=${isAdmin}
	$("#boardWriter").html(userId);
	
	var data = getAjax("/board/registerSEQ.json",json);
		//alert("리뷰글 번호 = " + data.registerSeq);
		boardseq = data.registerSeq;

	
	$("#boardseq").append(boardseq);
	
	//업로드 버튼을 클릭했을때 이미지 미리보기 초기화
	$("#uploadFile").on("click", function(){
		$('.preview').html("");
		$("#uploadFile").val("");
	});
	
	//파일업로드의 파일이름이 변했을때
	$("#uploadFile").change(function() {
		readInputFile(this);
	});
 	function readInputFile(input) {
		console.log(input.files);
		if(input.files.length!=0){
			var reader = new FileReader();
			reader.onload = function(e) {
				$('.preview').html("<img src="+ e.target.result +">");				
			}
			reader.readAsDataURL(input.files[0]);
			console.log(input.files[0].name);
		}
	}  
	
 	
 	$("#newRoute").on("click", function(){
		
		var mid=userId;
		console.log(mid);
		window.open("./board_newRoute.do?userId="+mid, "북마크 새창", "width=1000, height=700, toolbar=no, menubar=no, scrollbars=no, resizable=yes" );  

	});	
 	
 	
 	
	//전체 저장 버튼을 눌렀을때
	$("#allsavebtn").on("click", function(){
			var formData = new FormData();
			var inputFile = $("input[name='uploadFile']");
			
			console.log(inputFile);

			var files = inputFile[0].files;

			//add filedata to formdata
			formData.append("uploadFile", files[0]);
			console.log(formData);
			formData.append("previewBno", boardseq);
			formData.append("previewID", userId);
			formData.append("previewPlace", $("#sumPlace").val());
			formData.append("previewTag", $("#sumTag").val());
			
			console.log(files);
			//파일을 업로드할 경우
			if( files.length != 0){
				formData.append("previewImg", boardseq+"_"+files[0].name);
				formData.append("previewImg1", "/resources/img/flag/review/");
				console.log(files[0].name);
			}

			
	
			console.log(formData);
			
			var  token = $("meta[name='_csrf']").attr("content");
			var  header = $("meta[name='_csrf_header']").attr("content");
			
			$.ajax({
				url : "/board/insertPreview.json",
				processData : false,
				contentType : false,
				data : formData,
				async:false,
				type : 'POST',
		        beforeSend: function(xhr) {
		            xhr.setRequestHeader(header, token);
		        },
				success : function(data) {
					dataInfo=data;
					if(dataInfo.success=="Y"){
						
						
						
						
						
						for(var j=0; j<DeparArr.length; j++){
							
							json={};
							json.mid = userId;
							var data = getAjax("/board/selectseqperplan.json", json);
							console.log(data.list[0].NEXTVAL);
							json.rtseqperplan= data.list[0].NEXTVAL;
							
							
							json.rtdeplat = DeparArr[j].lat();
							json.rtdeplng = DeparArr[j].lng();
							json.rtarrlat = ArrveArr[j].lat();
							json.rtarrlng = ArrveArr[j].lng();
							json.rbseq = boardseq;
							
							if(WaypoArr[j].length>0){
								for(var k=0; k<WaypoArr[j].length; k++){
									json.rtwaypolat = WaypoArr[j][k].location.lat();
									json.rtwaypolng = WaypoArr[j][k].location.lng();
									var data1 = getAjax("/board/insertRoute.json", json);
								}
							}else{
								json.rtwaypolat = "";
								json.rtwaypolng = "";
								var data1 = getAjax("/board/insertRoute.json", json);
							}
							
							json={};
							json.rbseq = boardseq;
							json.rtseqperplan= data.list[0].NEXTVAL;
							json.mid = userId;
							json.trday = (j+1);

							var data2 = getAjax("/board/insertTravelRoute.json", json);
						}
						
						
						//-----------tag
						var inserttag = $("#sumTag").val();
						var a = inserttag.replace(/(\s*)/g, "") 
						var splstr = a.split('#');
						json= {};
						
						console.log(a);
						console.log(splstr);
						
						json.rbseq = boardseq;
						for(var i=1 ; i<splstr.length;i++){
							json.tag = splstr[i];
							var data = getAjax("/board/inserttag.json", json)
						}
						console.log(json.rbseq);
						//---------------tag
						
						
						
						
						if(data1.addRoute == true){
							if(data2.addTravelRoute==true){
								alert("게시글 성공적으로 등록되었습니다.");
								location.href="./board_main.do";
							}
							
						}else{
							alert("경로 저장에 실패하였습니다.");
							return;
						}
						
						
						
					} else{
						alert("빈칸을 입력하였습니다");
					}
					
					

				}, error : function(jqXHR, textStatus, errorThrown) {
					console.log(jqXHR.responseText);
				}
			});	
			
			
			
			
			
			
	});
	
	tripList(page_no);
	bookmarkList(page_no);
	
	
	
});	


////////////////////////////////////////====$(document).ready(function(){끝 부분====/////////////////////////////////////////////////////////////////////////////////////////////////

function addradiobtn(){
	
	
	page_no=page_no+1;
	rai = $("input[name=pos]").length;
	if(rai < 8){
	alert("추가");
	console.log(rai);
	var radhtml = "<input type='radio' name='pos' id='pos"+(rai + 1)+"' value='"+(rai + 1)+"' style='margin-left: 17px;'>";

	var lihtml = "";
	lihtml += "		<li style='height: 500px;'>";
	lihtml += "			<div class='mapinfo'>";
	lihtml += "				</div>";
	lihtml += "				<div id='right-panel' >";
	lihtml += "					<div id='tripList_div'>";
	lihtml += "						<div>";
	lihtml += "							<input type='button' id='addradiobtn' class='btn btn-primary' onclick='addradiobtn()'value='+'/>";
	lihtml += "						</div>	";
	lihtml += "					</div>";
	lihtml += "					<div id='bookmark_div'>";
	lihtml += "						<b>북마크 :</b>";
	lihtml += "						<select id='bookmark"+(rai+1)+"' name='bookmark' onchange='bookmarkinfo("+(rai+1)+");''>";
	lihtml += "							<option selected>리스트를 선택해주세요.</option>";
	lihtml += "						</select>";
	lihtml += "					</div>";
	lihtml += "				</div>";
	lihtml += "				<div class='map' id='map"+(rai+1)+"' style='height:500px;  width:85%'></div>";
	lihtml += "			</li>				";
	
	
	$("#pos"+rai).after(radhtml);
	$(lihtml).appendTo("#add");

	$maps = $('.map');
    
	arr=[];
    $.each($maps, function (i, value) {
    	
    	console.log("i=="+ i);
		console.log(value);
		
        var mapDivId = $(value).attr('id');

        maps[mapDivId] = new google.maps.Map(document.getElementById(mapDivId), {
            zoom:3,
            center: {lat: 35.1379222, lng:129.05562775}
        });

        arr.push(maps[mapDivId]);
        console.log(arr);

    })
	}else{
		alert("더 이상 추가 안됌");
	}
	bookmarkList();
	
	
	$("input:radio[name='pos']").change(function(){
    	var checked= $("input:radio[name='pos']:checked").attr('id');
    	console.log(checked);
    	ttrday = checked.substring(3);
    	console.log(ttrday);
    		
    });
    
}

//평점 가져오기
function grades(i, dLength, page_no) {
	json = {};
	json.PLACE = $("#placename"+i+"").html();
	json.ID = $("#boardWriter").html();
	json.LIST = $("#tripList_"+page_no+" option:selected").text();
	data = getAjax("/tripList.json", json);
	console.log(data.data);
	for(j=0; j<dLength; j++) {
		if($("#placename"+j+"").html() == data.data[j].PLACE) {
			var grade = parseFloat(data.data[j].GRADE)*2;
			for(k=0; k<grade; k++) {
				$("#star"+j+" span").eq(k).addClass( 'on' );
				$("#grade"+j+"").text(($("#star"+j+" span[class='starR2 on']").length + $("#star"+j+" span[class='starR1 on']").length)/2);
			}
		}
	}
	//평점
	$('.starRev span').click(function(){
		  $(this).parent().children('span').removeClass('on');		//별점의 on 클래스 전부 제거
		  $(this).addClass('on').prevAll('span').addClass('on');  	//클릭한 별과, 그 앞 까지 별점에 on 클래스 추가
		  return false;
	});
}

//평점 올리기
function graded(i){
	$("span[name='starR']").click(function(){
		json = {};
		$("#grade"+i+"").text(($("#star"+i+" span[class='starR2 on']").length + $("#star"+i+" span[class='starR1 on']").length)/2);
		json.ID = $("#boardWriter").html();
		json.PLACE = $("#placename"+i+"").html();
		json.GRADE = $("#grade"+i+"").html();
		console.log(json);
		data = getAjax("/updategrade.json", json);
		
	});
}



// 리뷰 등록
function reviewtextbtn(i){
	
	var data = getAjax("/board/reviewbno.json",null);
		alert("리뷰글 번호 = " + data.reviewbno);
		reviewbno[i] = data.reviewbno;
		console.log("i 값 == "+i);

		
	var rvtextbtn = "#text_div"+i;
	//alert("게시글 번호"+boardseq);
	$("#reviewtextbtn"+i+"").hide();
	var html = "";
	html +="<div class='form-group' style='margin-bottom: 0px;'>";
	html +=	"<label style=''>번호 "+reviewbno[i]+"</label>";
	html +="</div>";
	html +="<div class='form-group' style='margin-bottom: 0px;'>";
	html +=	"<label>제목</label>"
	html +=	"<input class='form-control' id='title"+i+"'></input>";
	html +="</div>";
	html +="<div class='form-group'>";
	html +=	"<label>내용</label>";
	html +=	"<textarea style='resize: none; height: 62px;' class='form-control' id='Content"+i+"'></textarea>";
	html +="</div>";
	html +=	"<button type='button' id='Savebtn"+i+"' class='btn btn-primary'>저장</button>";
	html +=	"<button type='button' id='closebtn"+i+"'onclick='closebtn("+i+")' class='btn btn-primary'>닫기</button>";
	$("#aa"+i+"").html(html);	
	
	 $("#Savebtn"+i+"").on("click",function(){
			insertTitle      = $("#title"+i+"").val();
			insertContent    = $("#Content"+i+"").val();

			confirmhtml(i);
			
	  		$("#boardSeq"+i+"").append(reviewbno[i]);
	  		$("#Title"+i+"").append(insertTitle);
			$("#Content"+i+"").append(insertContent);
			alert("이미지 "+placeinfo.IMG_NAME);
	  		json1.Bno        = boardseq;
	  		json1.ReviewBno  = reviewbno[i];
			json1.Title  	= insertTitle;
			json1.Content	= insertContent;
			json1.Place		= reviewPlace[i];
			json1.PlaceImg	= reviewimg[i];
			console.log(json1);
			var data = getAjax("/board/register.json",json1);
			
			if(data.success=="Y"){
				alert("리뷰가 저장되었습니다.");
			} else {
				alert("빈칸을 입력하셨습니다.");
			}

			
					
		});
}
//리뷰 수정
function modifybtn(i){
	$("#aa"+i+"").html("");
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
		html += "<button type='button' id='modifyconfirmbtn"+i+"'>수정</button>";
		html += "<button type='button' id='closebtn"+i+"' onclick='closebtn("+i+")'>취소</button>";
	$("#aa"+i+"").append(html);
	alert("수정 시퀀스 ="+reviewbno[i]);
	
	json.modifyBno = reviewbno[i];
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
		html += "<button type:'button' id='modifybtn"+i+"' onclick='modifybtn("+i+")' class='btn btn-primary'>수정</button>"	
		html += "</div>"; 
		
		$("#text_div"+i+"").append(html);
	} 

function closebtn(i){
	$("#aa"+i+"").html("");
	$("#reviewtextbtn"+i+"").show();
}

//저장된 장소 좌표 불러오기
function RCMplace(allrcmplace){

	var data = getAjax("RCMplacelist.json", json);
	rplatlng = data.RCMplacelist;
	
	 for(var i = 0; i< rplatlng.length; i++){
		//console.log("장소쓰~ = "+rplatlng[i].PLACE);
		json.rcmplace = rplatlng[i].PLACE;
		data = getAjax("RCMplaceLatLng.json", json);
		RpLL = data.RCMplaceLatLng;
		//console.log("좌표쓰~ = "+RpLL.P_LAT);
		allrcmplace[i] = RpLL;
		//console.log(rcmplace[0].P_NAME);
	} 
	 console.log("allrcmplace=="+allrcmplace);
	 return allrcmplace;
}


////select box 리스트
function tripList(page_no) {
	  json = {};
	  json.ID = $("#boardWriter").html();
	  data = getAjax("tripList.json", json);
	  var names = [];
	  var place = [];
	  for(i = 0; i < data.data.length; i++) {
			names[i] = data.data[i].MYRCM_LIST;
	  }
	  var uniqueNames = [];
	  $.each(names,function(i,value){
	  	if(uniqueNames.indexOf(value) == -1 ) uniqueNames.push(value);
	  });
	  console.log(uniqueNames);
	  for(j=0; j< uniqueNames.length; j++) {
	  	$('#tripList_'+page_no).append("<option value='"+j+"' >"+uniqueNames[j]+"</option>'");
	  }
	  console.log(data.data);
	  
}



function bookmarkList(){

	$("select[name=bookmark]").empty();
	json={};
 	json.mid = userId;
	var data = getAjax("/board/selectBMRoute1.json",json);

	
	for(var i=0; i<data.list.length; i++){
		
		json.bmrtseq = data.list[i].BM_RT_SEQ;
		var datart2 = getAjax("/board/selectBMRoute2.json", json);
		$("select[name=bookmark]").append("<option value='"+data.list[i].BM_RT_SEQ+"' >"+datart2.list[0].BM_NICK+"</option>'");
		
	}	
	
}

function bookmarkinfo(posnum){

	console.log(arr);
	console.log("posnum:"+posnum);
	var directionsRenderer = new google.maps.DirectionsRenderer;
	var directionsService = new google.maps.DirectionsService;
	var infoWindow = new google.maps.InfoWindow;
	directionsRenderer.setMap(arr[posnum-1]);

	var bkmark = $("#bookmark"+posnum+" option:selected").val();
	console.log(bkmark);
	waypts=[];
	json={};
	json.mid = userId;
	json.bmrtseq = bkmark;
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
        origin: DepartPosition , 													
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
	
	
	DeparArr[posnum-1]=DepartPosition;
	ArrveArr[posnum-1]=ArrivePosition;					// posnum : 여행일자, posnum-1 : 배열은 0부터 시작하니까

		
	WaypoArr[posnum-1]=waypts;

		
		
	}


//select box 선택시		여행리스트
function SetSelectBox(page_no) {
	var json2 ={};
	json.ID = userId;
	$("#review_div").empty();
	var tList = $("#tripList_"+page_no+" option:selected").text();
	data = getAjax("tripList.json", json);
	var dLength = data.data.length;
	for(i = 0; i < dLength; i++) {
		data = getAjax("tripList.json", json);
		if(data.data[i].MYRCM_LIST == tList) {
			selectedTrip();
			json2.mylist = tList;
		}
	}
	console.log("load()"+ tList);
	console.log("=================================");
	var daplace = getAjax("/SelectionplaceLatLng.json", json2);

	grades(i, dLength, page_no);
}

//관광지 보여주기
function selectedTrip() {
		var placeData = data.data[i].PLACE;
		var html="";
			json.PLACE = placeData;
			data = getAjax("/board/placeinfo.json",json);
			placeinfo = data.placeinfo;
			html +="<div id='review_div"+i+"' style='overflow:hidden;height:auto;''>";
			html +=	 "<div id='review_img' style=''>";
			html +=		"<div id='view_img' style='float: left; margin-right: 10px;'>";
			html +=			"<img src='./img/"+placeinfo.IMG_NAME+"' style='height: 150px; width: 150px;'/>";
			html +=		"</div>";
			html +=		"<button type='button' id='reviewtextbtn"+i+"' onclick='reviewtextbtn("+i+")' class='btn btn-primary'>쓰기</button>";
			html +=		"<div id='text_div"+i+"'style='float: left;width: 75%;'>";
			html +=		"<div id='placename"+i+"'style='float: left;width: 75%;'>"+placeData+"</div>";
			html +=			"<div id='aa"+i+"'>";
			html +=			"</div>";
			html +=		"</div>";
			html +=	 "</div>";
			html +="</div>";
			html +="<div id='star"+i+"' name='starDiv' class='starRev' style='margin-bottom:5vw;' >";
			for(j=0; j<5; j++) {
				html +="<span class='starR1' onclick='graded("+i+")' name='starR'>별1_왼쪽</span>";
				html +="<span class='starR2' onclick='graded("+i+")' name='starR'>별1_오른쪽</span>";
			}
			html +="<h4 id='grade"+i+"' style='margin-left:2px;width:150px;'></h4>";
			html +="</div>";
			
			reviewimg[i] = placeinfo.IMG_NAME;
			reviewPlace[i] = placeData;
		$("#review_div").append(html);	
		
	}



//---------------------


	
	
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
			json.mid = 'user0000';
			console.log(json.mid);
			var data = getAjax("./selectbookmarkseq.json", json);
			
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
					var data = getAjax("./insertBookmark.json", json);	
		        }
			}else{
				json.bmdeplat = DepartPosition.lat();
				json.bmdeplng = DepartPosition.lng();
				json.bmarrlat = ArrivePosition.lat();
				json.bmarrlng = ArrivePosition.lng();
				
				json.bmwaypolat = "";
				json.bmwaypolng = "";
				var data = getAjax("./insertBookmark.json", json);	
			}
		    
			
			if(data.addBookmark == true){
				alert("북마크 저장이 성공적으로 완료되었습니다.");
				location.href = "./maptest2.do";
			}else{
				alert("경로 저장에 실패하였습니다.");
				return;
			}
		
		}else{
			alert("저장하려는 여행 경로를 완성하세요.");
		}
	});
	
	





	
	function load(rcmplace){
		
		markers = [];
		
		var infoWindow = new google.maps.InfoWindow;
		
      	directionsRenderer.setMap(map);
      	console.log("==map=="+map.center);
      	directionsRenderer.setPanel(document.getElementById('navigator'));
      	
      	console.log("rcmplace == "+rcmplace);
      	
      	var customicon = {
        		url: 'http://drive.google.com/uc?export=view&id=1tZgPtboj4mwBYT6cZlcY36kYaQDR2bRM',
        		size: new google.maps.Size(25, 40),
        		origin: new google.maps.Point(0, 0),
        		anchor: new google.maps.Point(17, 34),
        		scaledSize: new google.maps.Size(25, 40)
      		};
      	
      	console.log($("#tripList option:selected").text());
      	console.log("==map=="+rcmplace.length);
      	
     	 for(var i = 0; i < rcmplace.length; i++){
        	console.log(rcmplace[i].P_NAME+"=="+rcmplace[i].P_LAT+"=="+rcmplace[i].P_LNG);
        	 marker1 = new google.maps.Marker({
        		position: new google.maps.LatLng(rcmplace[i].P_LAT, rcmplace[i].P_LNG),
            	icon: customicon,
        		map: map
          	});
        	 
        	 google.maps.event.addListener(marker1, 'click', (function(marker1, i) {
                 return function() {

                     //html로 표시될 인포 윈도우의 내용
                     var contentStr = "";
                     contentStr = "<div style='text-align : center; width: 100px;'><strong>"+rcmplace[i].P_NAME+"</strong><br>"
               			+ "<button type='button' onclick='departBtnclick()' >출발지로 설정</button>"
                 		+ "<button type='button' onclick='arriveBtnclick()'>도착지로 설정</button>"
                 		+ "<button type='button' onclick='addWayPoint()'>경유지로 설정</button></div>";

                     infowindow.setContent(contentStr);
                     
                     //인포윈도우가 표시될 위치
                     infowindow.open(map, marker1);
                     
                 }
             })(marker1, i));
      
             if (marker1) {
                 marker1.addListener('click', function() {
                     //중심 위치를 클릭된 마커의 위치로 변경
                     map.setCenter(this.getPosition());
  			  
                     //마커 클릭 시의 줌 변화
                     map.setZoom(13);
                   
                 });
             }
        }
      	
      	//if (navigator.geolocation) {
        	navigator.geolocation.getCurrentPosition(function(position) {
        		var pos = {
              		//lat: position.coords.latitude,
              		//lng: position.coords.longitude
              		lat: 51.047141,
              		lng: -114.058744								// 실제 사용시 정확한 현재위치 표시를 위해 주석처리 된 부분 풀어야함
        		};
        		console.log("==map=="+rcmplace.length);

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
        //} else {
          // Browser doesn't support Geolocation
         // handleLocationError(false, infoWindow, map.getCenter());
        //}
	
      /////-----------------------------현재위치 받는 부분
      
      
      	// Create the search box and link it to the UI element. 검색 창을 만들어 UI 요소에 연결합니다.
      	input = document.getElementById('pac-input');
      	qqq = document.getElementById('qqq');
		
      	searchBox = new google.maps.places.SearchBox(input);
      	selectBox = rcmplace;
      	//map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
      	//map.controls[google.maps.ControlPosition.TOP_LEFT].push(rtpn);
      	console.log(searchBox);
      	console.log(selectBox);
      	console.log("hihihihi");
      	console.log("qqq"+$("#tripList option:selected").text());
      	console.log("rcmplace=="+rcmplace);
      	// Bias the SearchBox results towards current map's viewport.
      	//SearchBox 결과를 현재지도의 뷰포트로 편향시킵니다.
      	map.addListener('bounds_changed', function() {
        	searchBox.setBounds(map.getBounds());
      	});
  
      	// Listen for the event fired when the user selects a prediction and retrieve
      	//사용자가 예측을 선택하고 검색 할 때 발생하는 이벤트 수신
      	// more details for that place.
      	//해당 장소에 대한 자세한 내용
      	searchBox.addListener('places_changed', function() {
        	places = searchBox.getPlaces();
        	console.log(places);
        	if (places.length == 0) {
        		return;
        	}

        	// Clear out the old markers.
        	//오래된 마커를 지우십시오.
       		markers.forEach(function(marker) {
          		marker.setMap(null);
        	});
        	markers = [];

        	// For each place, get the icon, name and location.
        	//각 장소마다 아이콘, 이름 및 위치를 가져옵니다.
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
          		//각 장소에 대한 마커를 만듭니다.
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
	
	
	
	
	
	
	
	
	
	
	
	







</script>
</head>



