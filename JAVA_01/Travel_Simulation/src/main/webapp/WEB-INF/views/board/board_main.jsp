<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
	<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>

<script type="text/javascript">

var index = [];
var userId = "";
var searchType = "";
var keyword = "";	
var nowPage=0;
var total=0;
var sel=0;
	$(document).ready(function(){
		
 		if(total==0){
 			boardInfinityView();
		} 
		

		//검색창에 검색어를 쳤을때
		$(".keyword").on("keyup", function () {
			searchType = $('.searchType').val();
			keyword = $('.keyword').val();
			nowPage=0;
			total=0;
			$("#rowtext-center").empty();
			boardInfinityView();
		});
		
		//게시글 등록화면으로 이동
		$("#toInsertRB").on("click", function(){
			location.href="./board.do";
		});	
		
		
		$(window).scroll(function() {
		    var scrolltop = parseInt ( $(window).scrollTop() );
		    if( scrolltop >= $(document).height() - $(window).height() - 5){
		    	boardInfinityView();
		    }
		});
	});
	
	function boardInfinityView(){
    	var json={};
    	sel=8;
    	json.cntPerPage=sel;
    	nowPage=nowPage+1
    	json.nowPage=nowPage;
    	json.keyword=keyword;
    	json.searchType=searchType;

    	var dataInfo=null;
    	dataInfo=getAjax("./infinityLoding.json",json);
    	console.log(total);
    	console.log(dataInfo.paging.total);

    	if(total<dataInfo.paging.total){
    		total=total+8;
	    	var info=dataInfo.viewAll;
	    	console.log(info);
	    	
	    	

	    	var html="";
	    	for(i=0;i<info.length;i++){
		     	console.log(info[i].PRV_HASHTAG);
	    		html += "<div class='col-lg-3 col-md-6 mb-4 review_div'>";
				html += "<div class='card h-100' id='card h-100' onclick='reviewlookup( "+info[i].PRV_SEQ+")'>";
				html += "<img class='card-img-top'style='height: 50%;' src='"+info[i].PRV_IMGFOLDER+info[i].PRV_IMG+"'>";
				html += "<div class='card-body'>";
				html += "<p class='card-text' id='boardBno' style='display: none;'>게시글 번호 "+info[i].PRV_SEQ+"</p>";
				html += "<h4 class='card-title'>"+info[i].PRV_TITLE+"</h4>";
				html += "<p class='card-text' style='font-size: 10px;'>"+info[i].M_ID+"</p>";
				html += "<p class='card-text'>";
				
					json={};
	        		json.rbseq = info[i].PRV_SEQ;
	        	
	         		var dataa = getAjax("/board/gettag.json", json)	//ajax
	        	
	          		for (var k = 0; k < dataa.list.length; k++) {
	          			var urltag = encodeURI(dataa.list[k].TAGNAME, 'UTF-8');
	        	   		html+= "<a href='/board_tag.do?tagname="+urltag+"' style='color : black;'> #" + dataa.list[k].TAGNAME + "</a>";
	        		} 
				html += "</div></p>";
				html += "</div>";
				html += "</div></div>";	 
				
	    	}
	    	$("#rowtext-center").append(html);
	    	
	    	
    	} else {
    		var html="게시글목록의 끝입니다."
    		$("#infinityLoading").html(html);
    	}
	}
	
	function reviewlookup(index){
		location.href= 'lookup.do?seq='+index+'';
	}
</script>
	


  <!-- Page Content -->
  <div class="container">
    <header class="jumbotron my-4">
 		 <div id="aaa">
 		 		<a href="board.do">
    			<h2 style="padding-top: 20px;">여행 게시글</h2>
    			</a>
    			
    	<!-- 사용자나 관리자로 로그인했을 경우 게시글 등록버튼 활성화 -->
		<div>	
			<sec:authorize access="hasAnyRole('ROLE_ADMIN','ROLE_MEMBER')">										
				<input type="button" id="toInsertRB" value="등록" class="btn btn-toggle"> 
			</sec:authorize>
		</div>
			
			<!-- 검색창 -->
			<div style="text-align: right; display: inline-flex; float:right;">
				<select class="searchType" name="searchType">
					<option value="t">제목</option> 
					<option value="w">작성자</option>
					<option value="all">제목+작성자</option>
				</select>
				<input class="form-control keyword" type="text"  name="keyword" onkeyup="enterkey('#btnSearchPRV');" placeholder="검색어를 입력하세요"/>
				<button id="btnSearchPRV" class="btn btn-primary">Search</button>
			</div>	
		</div>
    </header> 
    


    <!-- Page Features -->
    
    
    <div class="row text-center" id="rowtext-center">

    </div>
    <div id="infinityLoading" style="font-size: xx-large; text-align: center;"></div>
    
    
    <!-- /.row -->	
      <!-- Scroll to Top Button-->
 	<button type="button" onclick="goTop()" class="btn btn-toggle" style="position:fixed; bottom:10%; left:90%; background-color: lavender;">맨 위로 ↑</button>

  </div>
  <!-- /.container -->

  <!-- Bootstrap core JavaScript -->
