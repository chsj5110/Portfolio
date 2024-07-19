<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>

<style>
	.reviews0 {
		float:left;
		width:20%;
		height:30px;
		text-align:center;
		margin-left:10px;
	}
	
	.reviews1 {
		float:left;
		width:60%;
		height:30px;
		text-align:center;
		margin-left:10px;
	}
	
	.reviews2 {
		float:left;
		width:10%;
		height:30px;
		text-align:center;
		margin-left:10px;
	}
	
</style>

<script type="text/javascript">
var json = {};
var data = null;
var nowPage=0;
var sel=0;
var total=0;
var searchType="";
var keyword="";
	$(document).ready(function(){
		$("#noDiv").hide();
		
 		if(total==0){
			areaInfinityView();
		}
		
		$(window).scroll(function() {
		    var scrolltop = parseInt ( $(window).scrollTop() );
		    if( scrolltop >= $(document).height() - $(window).height() - 5 ) {
		   		areaInfinityView();

		   		
		    }
		});	
		
		$("#btnSearchArea").on("click",function(){
			searchType=$("#searchType").val();
			keyword=$("#areaKeyword").val();
			nowPage=0;
			total=0;
			console.log(searchType);
			$("#bodyDiv").empty();
	   		areaInfinityView();
	   	
		});		
		
		//search입력시 엔터키 즉시적용
		$(document).keyup(function() {
			  $("#btnSearchArea").click();
			});
		
		
		
	});
	
	
	//관광지 목록 무한스크롤로 출력
	function areaInfinityView(){
    	var json={};
    	sel=8;
    	json.cntPerPage=sel;
    	nowPage=nowPage+1
    	json.nowPage=nowPage;
    	json.keyword=keyword;
    	json.searchType=searchType;
    	console.log(json);

    	var dataInfo=null;
    	dataInfo=getAjax("./infinityAreaLoding.json",json);
    	console.log(dataInfo.paging.total);

    	if(total<dataInfo.paging.total){
    		total=total+8;
	    	var info=dataInfo.viewAll;
	    	console.log(info);
	    	console.log("tatal="+total);

	    	var html="";
	    	for(i=0;i<info.length;i++){
				html+= "<div class='col-lg-3 col-md-6 mb-4' name='ctyDiv' id='ctyBox"+info[i].IMG_SEQ+"' data-toggle ='modal' data-target='#myModal' onclick='ctyModal("+info[i].IMG_SEQ+")'>";
		        html+= "<img class='card-img-top' style='height:10vw;' src='./img/"+ info[i].IMG_NAME +"' alt=''>";
		        html+= "<div class='card-body' style='color:black;height:6vw;padding: 0 0 0 0;margin-top: 10px;'>";
		        html+= "<h4 class='card-title' name='country'>"+ info[i].CTY_NAME+"("+info[i].AREA+")</h4>";
		        html+= "<p class='card-text' id='dName"+info[i].IMG_SEQ+"'>"+ info[i].D_NAME +"</p>";
		        html+= "</div>";
		        html +="<div id='star"+info[i].IMG_SEQ+"' name='starDiv' class='starRev' style='width:75%;margin-left:18%;'>";

    
		        jsons={};
		        jsons.PLACE = info[i].D_NAME;
		        datas = getAjax("viewgrade.json", jsons);
		    	if(datas.data == null) {
			        for(j=0; j<5; j++) {
						html +="<span class='starR1' name='starR'>별1_왼쪽</span>";
						html +="<span class='starR2' name='starR'>별1_오른쪽</span>";
					}
		    		html +="<h4 id='grade"+info[i].IMG_SEQ+"' style='margin-left:2px; display: inline-block;'></h4>";
		    	} else {
			    	var round = parseFloat(datas.data.ROUND)*2;
			    	rounds = round - Math.floor(round);
			    	if(Math.round(rounds*100)/10.0 > 0.5) {
			    		round = Math.floor(parseFloat(datas.data.ROUND)*2);
			    	}
				    for(k=0; k<round; k++) {
				        if(k%2==0){
				        	html +="<span class='starR1 on' name='starR'>별1_왼쪽</span>";
				        } else {
				        	html +="<span class='starR2 on' name='starR'>별1_오른쪽</span>";
				        }										    		
			    	}
				    for(j=round; j<10; j++) {
				        if(j%2==0){
				        	html +="<span class='starR1' name='starR'>별1_왼쪽</span>";
				        } else {
				        	html +="<span class='starR2' name='starR'>별1_오른쪽</span>";
				        }	
				    }
				    html +="<h4 id='grade"+info[i].IMG_SEQ+"' style='margin-left:2px; display: inline-block;'>"+datas.data.ROUND+"</h4>";
		    	}
		    	
				html +="</div>";
		        html += "</div>"; 
		        
	    	}
	    	$("#bodyDiv").append(html); 	
	    	
    	} else {
    		var html="게시글목록의 끝입니다."
    		$("#infinityLoading").html(html);
    	}
	}

	
	//모달
	function ctyModal(i) {
		$("#insertModal").empty();
		$("#myModalLabel").html($("#dName"+i+"").html());
		var placeName = $("#dName"+i+"").html();
		json.D_NAME = $("#dName"+i+"").html();
		data = getAjax("areaInfo.json", json);
		var html="";
		html+="<div class='card shadow mb-4' style='width:100%;'>";
		html+="<div class='card-header py-3' style='display:flex;'>";
		html+= "<ul class='imgUl'>"
		for(j=0; j<data.data.length; j++) {
		    html+= "<li class='imgLi'>"
		    	html+= "<img class='card-img-top' style='height:10vw;' src='./img/"+ data.data[j].IMG_NAME +"' alt=''>";
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
		console.log(json);
		data = getAjax("/reviewSelect.json", json);
		console.log(data.data);
		html+="<div>";
		html+="<h4 style='margin-left:10px;'>리뷰</h4>";
		html+="</div>";
		if(data.data.length > 1) {
		html+="<div>";
		html+="<div class='reviews0'>제목</div>";
		html+="<div class='reviews1'>내용</div>"
		html+="<div class='reviews2'>작성자</div>";
		html+="</div>";
			for(k=0; k< 3; k++) {
				html+="<a id='reviewBtn"+k+"' href='/lookup.do?seq="+data.data[k].PREVIEWBNO+"' style='margin-bottom:5px;'>";
				html+="<div class='reviews0' style='text-align:left;'>"+textLengthOverCut(data.data[k].URV_TITLE, '8', '...')+"</div>";
				html+="<div class='reviews1' style='text-align:left;'>"+textLengthOverCut(data.data[k].URV_CONTENT, '20', '...')+"</div>";
				html+="<div class='reviews2'>"+data.data[k].M_ID+"</div>";
				html+="</a>";
			}
		} else {
			html+="<p>등록된 리뷰가 없습니다.</p>";
		}
		
		$("#insertModal").html(html);
	}
	
	//글자수 자르기
	function textLengthOverCut(txt, len, lastTxt) {
        if (len == "" || len == null) { // 기본값
            len = 20;
        }
        if (lastTxt == "" || lastTxt == null) { // 기본값
            lastTxt = "...";
        }
        if (txt.length > len) {
            txt = txt.substr(0, len) + lastTxt;
        }
        return txt;
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
  
  
	//페이징-한번에 보여주는 게시글의 수
	function selChange() {
		sel = $('.cntPerPage').val();
		location.href="./board_main.do?nowPage=${paging.nowPage}&cntPerPage="+sel+"&keyword=${paging.keyword}&searchType=${paging.searchType}";
	}
	
</script>


  <!-- Page Content -->
  
  <div class="container">

    <!-- Jumbotron Header -->
    <header class="jumbotron my-4">
      <h2>관광지 둘러보기</h2>
    </header>
	
	<!-- 검색창 -->
	<div>		
		<div style="text-align: right; display: inline-flex; margin-bottom: 1.5rem!important;">
			<select class="searchType" id="searchType">
				<option value="all">전체</option>
				<option value="n">국가명/지역명</option> 
				<option value="d">관광지명</option>
			</select>
			<input class="form-control keyword" type="text"  id="areaKeyword" onkeyup="enterkey('#btnSearchArea');" placeholder="search"/>
			<button id="btnSearchArea" class="btn btn-primary">Search</button>
		</div>	
	</div>

    <!-- Page Features -->
    <div id="noDiv">
  		<h1>검색된 결과가 없습니다.</h1>
  	</div>
    <div class="row text-center" id="bodyDiv">
    </div>
    <div class="row text-center" id="infinityLoading">
    </div>
    
    <!-- Scroll to Top Button-->
 	<button type="button" onclick="goTop()" class="btn btn-toggle" style="position:fixed; bottom:10%; left:90%; background-color: lavender;">맨 위로 ↑</button>
    
    <!-- /.row -->

  </div>
  <!-- /.container -->