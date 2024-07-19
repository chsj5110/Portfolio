<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
	<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>


<script>

var dr="delete";

//var keyword="";
$(document).ready(function() {
	var sel = $('.cntPerPage').val();
	var keyword = "${paging.keyword}"
	var type="${type}";
	var list={};
	var deleted="${paging.searchType}"
	list="${viewAll}"
	
	if(deleted=="Y"){
		$(".restoreBtn").show();
	} else {
		$(".deleteBtn").show();
	}
 		
		//게시판별 목록 보기
		$("#boardType").on("change", function(){
			$("#tb").html("");
			type=$("#boardType").val();
			location.href="./adminBoardList.do?nowPage=${paging.nowPage}&cntPerPage="+sel+"&keyword="+keyword+"&type="+type+"&deleted="+deleted;
		});
		
		//게시글 검색기능
		$("#btnSearchAdminBoard").on("click", function () {
			keyword = $('.keyword').val();
			location.href="./adminBoardList.do?nowPage=${paging.nowPage}&cntPerPage="+sel+"&keyword="+keyword+"&type="+type+"&deleted="+deleted;
		});
		
	//게시물 삭제	
	$(".deleteBtn").on("click", function(){
		if(confirm("정말로 삭제하시겠습니까?")){
			var jsond={};
			jsond.seq=this.id.split("_")[1];
			
			if(this.value=="QNA"){	
				data= getAjax("./deleteQB.json",jsond);
			}
			
			if(this.value=="공지"){	
				data= getAjax("./deleteNB.json",jsond);
			}
			
			if(this.value=="자유게시판"){	
				data= getAjax("./deleteFB.json",jsond);
			}
			
			if(this.value=="리뷰게시판"){	
				data= getAjax("./deleteRB.json",jsond);
			}
			location.reload();
		}
	});
	
	//게시물 복구
	$(".restoreBtn").on("click", function(){
		if(confirm("정말로 복구하시겠습니까?")){
			var jsonr={};
			jsonr.seq=this.id.split("_")[1];
			
			if(this.value=="QNA"){	
				jsonr.type="QB";
			}
			
			if(this.value=="자유게시판"){	
				jsonr.type="FB";
			}
		
			if(this.value=="리뷰게시판"){	
				jsonr.type="PRV";
			}
			
			if(this.value=="공지"){	
				jsonr.type="NB";
			}
			data= getAjax("./restoreBoard.json",jsonr);
			location.reload();
		}
	});
	
	
	$('.cntPerPage').on("change", function(){
		sel = $('.cntPerPage').val();
		location.href="./adminBoardList.do?nowPage=${paging.nowPage}&cntPerPage="+sel+"&keyword=${paging.keyword}&type=${type}&deleted="+deleted;
	});
	
	$("#deleteAndRestore").on("change", function(){
		deleted = $('#deleteAndRestore').val();
		location.href="./adminBoardList.do?nowPage=${paging.nowPage}&cntPerPage="+sel+"&type=${type}&deleted="+deleted;
	});

		
});	

</script>


<div>
	<h4>게시글 관리페이지</h4>
</div>

<div>
	<!-- 한페이지에 보여줄 게시글 목록 숫자 선택옵션 -->
	<select class="cntPerPage" name="sel">
		<option value="20"
			<c:if test="${paging.cntPerPage == 20}">selected</c:if>>20개 보기</option>
		<option value="50"
			<c:if test="${paging.cntPerPage == 50}">selected</c:if>>50개 보기</option>
		<option value="100"
			<c:if test="${paging.cntPerPage == 100}">selected</c:if>>100개 보기</option>
		<option value="200"
			<c:if test="${paging.cntPerPage == 200}">selected</c:if>>200개 보기</option>
	</select>

	<select id="deleteAndRestore">
		<option value="N"<c:if test="${paging.searchType == 'N'}">selected</c:if>>삭제하기</option>
		<option value="Y"<c:if test="${paging.searchType == 'Y'}">selected</c:if>>복구하기</option>
	</select>


	<select id="boardType">
		<option value="ALL"<c:if test="${type == 'ALL'}">selected</c:if>>모두</option>
		<option value="PRV"<c:if test="${type == 'PRV'}">selected</c:if>>리뷰게시판</option>
		<option value="FB"<c:if test="${type == 'FB'}">selected</c:if>>자유게시판</option>
		<option value="NB"<c:if test="${type == 'NB'}">selected</c:if>>공지사항</option>
		<option value="QB"<c:if test="${type == 'QB'}">selected</c:if>>Q&A</option>
	</select>
	
	<input class="keyword" type="text"  name="keyword" onkeyup="enterkey('#btnSearchAdminBoard');" value="${paging.keyword}" placeholder="제목이나 글쓴이를 검색"/>
	<button id="btnSearchAdminBoard" class="btn btn-primary">Search</button>
	
	<table>
		<tr>
			<td>게시판</td>
			<td>공개여부</td>
			<td>글번호</td>
			<td>제목</td>
			<td>글쓴이</td>
			<td>최종 작성일</td>
			<td>비고</td>
		</tr>	
		
		<tbody id="tb">
			<c:forEach items="${viewAll }" var="list">
				<tr>
					<td>${list.CATEGORY}</td>
					<td>${list.OPENCHK}</td>
					<td>${list.SEQ}</td>  
						<td><a class='readFBLink' href='./${list.PAGE}.do?seq=${list.SEQ}' value="${list.SEQ}">${list.TITLE}</a></td>
						<td>${list.ID}</td>
					<td class='deleteBtn' style="display:none;">${list.CDATE}</td>
					<td class='restoreBtn' style="display:none;">${list.DDATE}</td>
					<td>
						<button class='deleteBtn' id='deleteBoard_${list.SEQ}' value="${list.CATEGORY}" style="display:none;">삭제</button>
						<button class='restoreBtn' id='restoreBoard_${list.SEQ}' value="${list.CATEGORY}" style="display:none;">복구</button>
					</td>
				</tr>
			</c:forEach>	
		</tbody>
	</table>
	<!-- 게시글 목록 페이지 이동 -->
	<div style="display: block; text-align: center;">		
		<c:if test="${paging.startPage != 1 }">
			<a href="./adminBoardList.do?nowPage=${paging.startPage - 1 }&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&type=${type}&deleted=${paging.searchType}">&lt;</a>
		</c:if>
		<c:forEach begin="${paging.startPage }" end="${paging.endPage }" var="p">
			<c:choose>
				<c:when test="${p == paging.nowPage }">
					<b>${p }</b>
				</c:when>
				<c:when test="${p != paging.nowPage }">
					<a href="./adminBoardList.do?nowPage=${p }&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&type=${type}&deleted=${paging.searchType}">${p }</a>
				</c:when>
			</c:choose>
		</c:forEach>
		<c:if test="${paging.endPage != paging.lastPage}">
			<a href="./adminBoardList.do?nowPage=${paging.endPage+1 }&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&type=${type}&deleted=${paging.searchType}">&gt;</a>
		</c:if>
	</div>
</div>

