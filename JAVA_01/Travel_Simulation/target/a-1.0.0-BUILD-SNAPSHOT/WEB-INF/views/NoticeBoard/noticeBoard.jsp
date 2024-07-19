<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="sec"
    uri="http://www.springframework.org/security/tags"%>

<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>


<link href="/../../resources/css/board.css" rel="stylesheet">
<script>
	$(document).ready(function() {		
		$("#toInsertNB").on("click", function(){
			location.href="./adminInsertNB.do";
		});
		
		$(".readNBLink").on("click", function(){
			location.href="./readNB.do?seq="+$(this).attr("value");			
		});		
	});
	
	function selChange() {
		var sel = document.getElementById('cntPerPage').value;
		location.href="./noticeBoard.do?nowPage=${paging.nowPage}&cntPerPage="+sel;
	}
	

</script>

<!-- Main Content -->
<div id="content">
	<!-- Begin Page Content -->
	<div class="container-fluid">
	
		<!-- Page Heading -->
		<h1 class="h3 mb-2 text-gray-800">공지사항</h1>
		<p class="mb-4">
			사이트와 관련된 공지사항을 확인해 보세요.
		</p>
	
		<div class="card-body">
			<div class="table-responsive">
				<!-- 페이징 옵션 -->
				<div style="float: right;">
					<select id="cntPerPage" name="sel" onchange="selChange()">
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
					
				<table class="table table-bordered" id="nb_dataTable" width="100%"
					cellspacing="0">
	
					<tbody id="NBbody">
						<c:forEach items="${viewAll }" var="list">
							<tr>
								<td>
									<div style='float:left;'>
										<div class='list_seq'>
											#${list.NB_SEQ}
		 								</div>
		 								<div class='list_title'>
		 									<a class='readNBLink' href='#' value="${list.NB_SEQ}">
		 										${list.NB_TITLE}
		 									</a>
		 								</div>
		 							</div>
		 							<div style='float:right;'>
		 								<div class='list_writer'>
											관리자
										</div>
										<div class='list_date'>
											${list.NB_CREATEDATE}
										</div>
									</div>
								</td>
							</tr>
						</c:forEach>
					</tbody>
				</table>
				
				<div style="display: block; text-align: center;">		
					<c:if test="${paging.startPage != 1 }">
					<a href="./noticeBoard.do?nowPage=${paging.startPage - 1 }&cntPerPage=${paging.cntPerPage}">&lt;</a>
					</c:if>
					<c:forEach begin="${paging.startPage }" end="${paging.endPage }" var="p">
						<c:choose>
							<c:when test="${p == paging.nowPage }">
								<b>${p }</b>
							</c:when>
							<c:when test="${p != paging.nowPage }">
								<a href="./noticeBoard.do?nowPage=${p }&cntPerPage=${paging.cntPerPage}">${p }</a>
							</c:when>
						</c:choose>
					</c:forEach>
					<c:if test="${paging.endPage != paging.lastPage}">
						<a href="./noticeBoard.do?nowPage=${paging.endPage+1 }&cntPerPage=${paging.cntPerPage}">&gt;</a>
					</c:if>
				</div>			
				
				<div>					
					<sec:authorize access="hasRole('ROLE_ADMIN')">
						<input type="button" id="toInsertNB" value="등록" class="btn btn-toggle">
					</sec:authorize>
				</div>
			</div>
		</div>
	</div>
	<!-- /.container-fluid -->
</div>
<!-- end of Main Content-->