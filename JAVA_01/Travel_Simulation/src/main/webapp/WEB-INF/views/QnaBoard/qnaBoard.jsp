<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
	<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>
<%@ taglib prefix="sec"
    uri="http://www.springframework.org/security/tags"%>

<link href="/../../resources/css/board.css" rel="stylesheet">

<script>
	$(document).ready(function() {
		
		var sel = $('.cntPerPage').val();
		var searchType = "${paging.searchType}"
		var keyword = "${paging.keyword}"
		
		$("#toInsertQB").on("click", function(){
			location.href="insertQB.do"
		});
		
		
		$(".readQBLink").on("click", function(){
			location.href="./readQB.do?seq="+$(this).attr("value")+"&nowPage=${paging.nowPage}&cntPerPage="+sel+"&keyword="+keyword+"&searchType="+searchType;	
		});
		
		$("#btnSearchQB").on("click", function () {
			searchType = $('.searchType').val();
			keyword = $('.keyword').val();

			location.href="./qnaBoard.do?nowPage=${paging.nowPage}&cntPerPage="+sel+"&keyword="+keyword+"&searchType="+searchType;
		});
		

	});
	
	function selChange() {
		sel = $('.cntPerPage').val();
		location.href="qnaBoard.do?nowPage=${paging.nowPage}&cntPerPage="+sel;
	}
	
</script>


<!-- Main Content -->
<div id="content">
	<!-- Begin Page Content -->
	<div class="container-fluid">
	
		<!-- Page Heading -->
		<div style="display: grid;">
			<div>
				<h1 class="h3 mb-2 text-gray-800">Q&A</h1>
				<p class="mb-4">사이트 운영에 대해 궁금한 점이 있으시면 글을 작성해 보세요^^.</p>
			</div>
			<div style="text-align: right; display: inline-flex;">
				<select class="searchType" name="searchType">
					<option value="t"
						<c:if test="${paging.searchType == 't'}">selected</c:if>>제목</option> 
					<option value="c" 
						<c:if test="${paging.searchType == 'c'}">selected</c:if>>내용</option>
					<option value="w" 
						<c:if test="${paging.searchType == 'w'}">selected</c:if>>작성자</option>
					<option value="tc" 
						<c:if test="${paging.searchType == 'tc'}">selected</c:if>>제목+내용</option>
					<option value="all" 
						<c:if test="${paging.searchType == 'all'}">selected</c:if>>전체조건</option>
				</select>
				<input class="form-control keyword" type="text" name="keyword" 
					value="${paging.keyword}" placeholder="검색어를 입력하세요"/>
				<button id="btnSearchQB" class="btn btn-primary">Search</button>
			</div>
			<br>
		</div> 
	
		<div class="card-body">
			<div class="table-responsive">
	
				<div style="float: right;">
					<select class="cntPerPage" name="sel" onchange="selChange()">
						<option value="5"
							<c:if test="${paging.cntPerPage == 5}">selected</c:if>>5줄 보기</option>
						<option value="10"
							<c:if test="${paging.cntPerPage == 10}">selected</c:if>>10줄 보기</option>
						<option value="15"
							<c:if test="${paging.cntPerPage == 15}">selected</c:if>>15줄 보기</option>
						<option value="20"
							<c:if test="${paging.cntPerPage == 20}">selected</c:if>>20줄 보기</option>
					</select>
				</div> <!-- 옵션선택 끝 -->
	
				<table class="table table-bordered" id="qb_dataTable" width="100%"
					cellspacing="0">
	
					<tbody id="QBbody">
						<c:forEach items="${viewAll }" var="list">
							<tr>
								<td>
									<div style='float:left;'>
										<div class='list_seq'>
											${list.QB_SEQ}
		 								</div>
		 								<div class='list_title'>
		 									<a class='readQBLink' href='#' value="${list.QB_SEQ}">
		 										${list.QB_TITLE} 
		 										<font id="qb_answer">									
		 										</font>
		 									</a>
		 								</div>
		 							</div>
		 							<div style='float:right;'>
		 								<div class='list_writer'>
											${list.M_ID}
										</div>
										<div class='list_date'>
											${list.QB_CREATEDATE}
										</div>
									</div>
								</td>
							</tr>
						</c:forEach>
					</tbody>
				</table>
			
				<div style="display: block; text-align: center;">		
					<c:if test="${paging.startPage != 1 }">
						<a href="./qnaBoard.do?nowPage=${paging.startPage - 1 }&cntPerPage=${paging.cntPerPage}">&lt;</a>
					</c:if>
					<c:forEach begin="${paging.startPage }" end="${paging.endPage }" var="p">
						<c:choose>
							<c:when test="${p == paging.nowPage }">
								<b>${p }</b>
							</c:when>
							<c:when test="${p != paging.nowPage }">
								<a href="./qnaBoard.do?nowPage=${p }&cntPerPage=${paging.cntPerPage}">${p }</a>
							</c:when>
						</c:choose>
					</c:forEach>
					<c:if test="${paging.endPage != paging.lastPage}">
						<a href="./qnaBoard.do?nowPage=${paging.endPage+1 }&cntPerPage=${paging.cntPerPage}">&gt;</a>
					</c:if>
				</div>
	
				<div>		
					<sec:authorize access="hasAnyRole('ROLE_ADMIN','ROLE_MEMBER')">											
						<input type="button" id="toInsertQB" value="등록" class="btn btn-toggle"> 
					</sec:authorize>
				</div>
			</div>
		</div>
	</div>
	<!-- /.container-fluid -->
</div>
<!-- end of Main Content-->



