<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
	<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>

<script>	
	var dr="delete";

	$(document).ready(function() {
		var sel = $('.cntPerPage').val();
		var keyword = "${paging.keyword}"
		var list={};
		var deleted="${paging.searchType}"
		list="${viewAll}"
		
		if(deleted=="1"){
			$(".memeberDelete").show();
			$(".memberColumCreateDate").show();
		} else {
			$(".memeberRestore").show();
			$(".memberColumDeleteDate").show();
		}
	 		
			
		//게시글 검색기능
		$("#btnSearchAdminMembership").on("click", function () {
			keyword = $('.keyword').val();
			location.href="./adminMembership.do?nowPage=${paging.nowPage}&cntPerPage="+sel+"&keyword="+keyword+"&deleted="+deleted;
		});
		
					
		$(".memeberDelete").on("click", function(){
			if(confirm("정말로 삭제하시겠습니까?")){
				var jsond={};
				jsond.date = nowDate();
				jsond.seq=this.value;
				data= getAjax("./deleteMembership.json",jsond);
				
				location.reload();
			}
		});
		
		$(".memeberRestore").on("click", function(){
			if(confirm("정말로 복구하시겠습니까?")){
				var jsonr={};
				jsonr.seq=this.value;
				data= getAjax("./restoreMembership.json",jsonr);
				
				location.reload();
			}
		});	
	
	
		$('.cntPerPage').on("change", function(){
			sel = $('.cntPerPage').val();
			location.href="./adminMembership.do?nowPage=${paging.nowPage}&cntPerPage="+sel+"&keyword=${paging.keyword}&type=${type}&deleted="+deleted;
		});
		
		$("#deleteAndRestore").on("change", function(){
			deleted = $('#deleteAndRestore').val();
			location.href="./adminMembership.do?nowPage=${paging.nowPage}&cntPerPage="+sel+"&type=${type}&deleted="+deleted;
		});		
	});	
	
	//모달
	function ctyModal(i) {
		$("#insertModal").empty();
		$("#myModal").modal();
		$("#myModalLabel").html($("#id_"+i).html()+" 님의 정보");
		
		var htmll=getHtml("./memInfo.do");
		$("#insertModal").html(htmll);
		
		$("#memDeleteDiv").show();
		
		var json={};
		json.seq=i;
		
		var dataInfo=null;
		dataInfo=getAjax("./adminSelectMembership.json",json);

		var Info=null;
		Info=dataInfo.data;
		$("#showId").html(Info.M_ID);
		$("#showName").html(Info.M_NAME);
		$("#showEmail").html(Info.M_EMAIL);
		$("#showInterest").html(Info.M_INTEREST);
		$("#membershipCreateDate").html(Info.M_CREATEDATE);
		$("#membershipDeleteDate").html(Info.M_DELETEDATE);
		$(".memBtnSet").html("<button class='btn1 memeberDelete' value='"+Info.M_SEQ+"'>회원탈퇴</button>");

		//회원탈퇴
		$(".memeberDelete").on("click",	function() {
			if(confirm("정말로 탈퇴시키겠습니까?")){
				var jsond={};
				jsond.date = nowDate();
				jsond.seq=this.value;
				var data= getAjax("./deleteMembership.json",jsond);
				if(data.success=="Y"){
					location.reload();
				} else{
					alert("탈퇴시키지 못했습니다.");
				}
			}	
		});	
	}
	
	
	
</script>

<div>
	<h4>회원 관리페이지</h4>
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
		<option value="1"<c:if test="${paging.searchType == '1'}">selected</c:if>>삭제하기</option>
		<option value="0"<c:if test="${paging.searchType == '0'}">selected</c:if>>복구하기</option>
	</select>
	
	<input class="keyword" type="text"  name="keyword" onkeyup="enterkey('#btnSearchAdminMembership');" value="${paging.keyword}" placeholder="이메일이나 아이디 검색"/>
	<button id="btnSearchAdminMembership" class="btn btn-primary">Search</button>


	<table id="membershipAdminInfo">
		<tr class="memberRow">
			<td class='memberColumSeq'>
				회원번호
			</td>
			<td class='memberColumEmail'>
				회원이메일
			</td>
			<td class="memberColumId">
				회원아이디
			</td>
			<td class="memberColumCreateDate" style="display:none;">
				가입일
			</td>
			<td class="memberColumDeleteDate" style="display:none;">
				탈퇴일
			</td>
			<td class="memberColumBtn">
				탈퇴/복구
			</td>
		</tr>
		<tbody id="tbMemberAdmin">
			<c:forEach items="${viewAll }" var="list">
				<tr>
					<td class='memberColumSeq'>${list.M_SEQ}</td>  
					<td class='memberColumEmail'>${list.M_EMAIL}</td>
					<td class="memberColumId"><a class='readMemInfoLink' href='#' value="${list.M_SEQ}" onclick='ctyModal(${list.M_SEQ})'><font id="id_${list.M_SEQ}">${list.M_ID}</font></a></td>
					<td class="memberColumCreateDate" style="display:none;">${list.M_CREATEDATE}</td>
					<td class="memberColumDeleteDate" style="display:none;">${list.M_DELETEDATE}</td>
					<td>
						<button class='memeberDelete' value="${list.M_SEQ}" style="display:none;">탈퇴</button>
						<button class='memeberRestore' value="${list.M_SEQ}" style="display:none;">복구</button>
					</td>
				</tr>
			</c:forEach>	
		</tbody>	
	</table>

	

	<!-- 게시글 목록 페이지 이동 -->
	<div style="display: block; text-align: center;">		
		<c:if test="${paging.startPage != 1 }">
			<a href="./adminMembership.do?nowPage=${paging.startPage - 1 }&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&type=${type}&deleted=${paging.searchType}">&lt;</a>
		</c:if>
		<c:forEach begin="${paging.startPage }" end="${paging.endPage }" var="p">
			<c:choose>
				<c:when test="${p == paging.nowPage }">
					<b>${p }</b>
				</c:when>
				<c:when test="${p != paging.nowPage }">
					<a href="./adminMembership.do?nowPage=${p }&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&type=${type}&deleted=${paging.searchType}">${p }</a>
				</c:when>
			</c:choose>
		</c:forEach>
		<c:if test="${paging.endPage != paging.lastPage}">
			<a href="./adminMembership.do?nowPage=${paging.endPage+1 }&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&type=${type}&deleted=${paging.searchType}">&gt;</a>
		</c:if>
	</div>
</div>
	