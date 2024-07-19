<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
	<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>

<script type="text/javascript">

var index = [];
var userId = "";

	$(document).ready(function(){
		
		
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
		 <%
		 String name = java.net.URLDecoder.decode(request.getParameter("tagname"), "UTF-8");
		 
		 %>
		 var tagname = '<%= name%>';
		
		 html="";
		 html+="<h2 style='padding-top: 20px;' > 태그검색 : #"+tagname+"</h2>";
		 
		 $("#tagSearchTitle").html(html);
		 
		 var json={};
	    	json.tagname=tagname;
			console.log("tagname :" + tagname);
	    	var dataInfo=getAjax("board/getListfromTag.json",json);
	    	
	    	html="";
	    	for(i=0;i<dataInfo.list.length;i++){
	    		html += "<div class='col-lg-3 col-md-6 mb-4 review_div'>";	
	    		html += "<div class='card h-100' id='card h-100'>";	
	    		html += "<img class='card-img-top'style='height: 50%;' onclick='reviewlookup("+dataInfo.list[i].PRV_SEQ+")' src='"+dataInfo.list[i].PRV_IMGFOLDER+dataInfo.list[i].PRV_IMG+"'>";	
	    		html += "<div class='card-body'>";	
	    		html += "<p class='card-text' id='boardBno' style='display: none;'>게시글 번호 "+dataInfo.list[i].PRV_SEQ+"</p>";	
	    		html += "<h4 class='card-title' onclick='reviewlookup( "+dataInfo.list[i].PRV_SEQ+")'>"+dataInfo.list[i].PRV_TITLE+"</h4>";	
	    		html += "<p class='card-text' style='font-size: 10px;'>"+dataInfo.list[i].M_ID+"</p>";	
					 
					 json1={};
			         json1.rbseq = dataInfo.list[i].PRV_SEQ;
					 var dataa = getAjax("/board/gettag.json", json1)	//ajax
			        	
			          	for (var k = 0; k < dataa.list.length; k++) {
			          		console.log("hello?");
			          		var urltag = encodeURI(dataa.list[k].TAGNAME, 'UTF-8');
			          		html += "<a class='card-text' href='/board_tag.do?tagname="+urltag+"' style='color : black;'> #" + dataa.list[k].TAGNAME + "</a>";	
			        	}
					 	
					html += "</div></div></div>";	 
				
	    	}
	    	$("#rowtext-center").append(html);	
	    	
	    	
	    	
	    	
		
		//검색버튼을 클릭했을 경우
		$("#btnSearchPRV").on("click", function () {
			searchType = $('.searchType').val();
			keyword = $('.keyword').val();
			location.href="./board_main.do?keyword="+keyword+"&searchType="+searchType;
		});
		
		
		
		
		
	});
	
	function reviewlookup(index){
		alert("게시글 번호="+ index);
		location.href= "./lookup.do?seq="+index;
	}
	
	

	
	
</script>
	


  <!-- Page Content -->
  <div class="container">
    <header class="jumbotron my-4">
 		 <div id="aaa">
 		 	<div id="tagSearchTitle"></div>
    			
    	
			
			<!-- 검색창 -->
			<div style="text-align: right; display: inline-flex; float:right;">
				<select class="searchType" name="searchType">
					<option value="t"
						<c:if test="${paging.searchType == 't'}">selected</c:if>>제목</option> 
					<option value="h" 
						<c:if test="${paging.searchType == 'h'}">selected</c:if>>해시태그</option>
					<option value="w" 
						<c:if test="${paging.searchType == 'w'}">selected</c:if>>작성자</option>
					<option value="th" 
						<c:if test="${paging.searchType == 'th'}">selected</c:if>>제목+해시태그</option>
					<option value="all" 
						<c:if test="${paging.searchType == 'all'}">selected</c:if>>전체조건</option>
				</select>
				<input class="form-control keyword" type="text"  name="keyword" 
					value="${paging.keyword}" onkeyup="enterkey('#btnSearchPRV');" placeholder="검색어를 입력하세요"/>
				<button id="btnSearchPRV" class="btn btn-primary">Search</button>
			</div>	
		</div>
    	
 		<!-- 한페이지에 보여줄 게시글 수 옵션 -->
<%--   		<div>
			<select class="cntPerPage" name="sel" onchange="selChange()">
				<option value="8"
					<c:if test="${paging.cntPerPage == 8}">selected</c:if>>8줄 보기</option>
				<option value="12"
					<c:if test="${paging.cntPerPage == 12}">selected</c:if>>12줄 보기</option>
				<option value="16"
					<c:if test="${paging.cntPerPage == 16}">selected</c:if>>16줄 보기</option>
				<option value="20"
					<c:if test="${paging.cntPerPage == 20}">selected</c:if>>20줄 보기</option>
			</select>
		</div> --%>    	
    </header> 
    


    <!-- Page Features -->
    
    
    <div class="row text-center" id="rowtext-center">
			
    </div>
    <div id="infinityLoading" style="font-size: xx-large; text-align: center;"></div>
    
    
    <!-- /.row -->
    
 <%--    	<div style="display: block; text-align: center;">		
			<c:if test="${paging.startPage != 1 }">
				<a href="./board_main.do?nowPage=${paging.startPage - 1 }&cntPerPage=${paging.cntPerPage}">&lt;</a>
			</c:if>
			<c:forEach begin="${paging.startPage }" end="${paging.endPage }" var="p">
				<c:choose>
					<c:when test="${p == paging.nowPage }">
						<b>${p }</b>
					</c:when>
					<c:when test="${p != paging.nowPage }">
						<a href="./board_main.do?nowPage=${p }&cntPerPage=${paging.cntPerPage}">${p }</a>
					</c:when>
				</c:choose>
			</c:forEach>
			<c:if test="${paging.endPage != paging.lastPage}">
				<a href="./board_main.do?nowPage=${paging.endPage+1 }&cntPerPage=${paging.cntPerPage}">&gt;</a>
			</c:if>		
		</div> --%>

		
      <!-- Scroll to Top Button-->
 	<button type="button" onclick="goTop()" class="btn btn-toggle" style="position:fixed; bottom:10%; left:90%; background-color: lavender;">맨 위로 ↑</button>

  </div>
  <!-- /.container -->

  <!-- Bootstrap core JavaScript -->
