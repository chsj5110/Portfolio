<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<%@ taglib prefix="sec"
    uri="http://www.springframework.org/security/tags"%>

<link href="/../../resources/css/comment.css" rel="stylesheet">
<style>
img{
	width:100%;
}
</style>
<script>
	
	var user_id=null;
	var isAdmin=null;

	$(document).ready(function() {
		var seq="${seq}"
		
		user_id="${userId}"
		isAdmin=${isAdmin}
		
		var json= {};
		json.seq=seq;
		
		//조회한 Q&A 출력
		var dataInfo=null;
		dataInfo=getAjax("./readQB.json",json).data;
		
		if (dataInfo.QB_OPENCHK=='Y'||user_id==dataInfo.M_ID||isAdmin==true) {
		
			$("#qbReadTitle").html(dataInfo.QB_TITLE);
		
			$("#qbReadWriter").html(dataInfo.M_ID);
			$("#qbInsertDate").html(dataInfo.QB_CREATEDATE+" 등록");
			$("#qbUpdateDate").html(dataInfo.QB_UPADATEDATE+" 수정");	
			$("#qbReadContent").html(dataInfo.QB_CONTENT);
		
		
		} else {
			alert("비공개 게시글 입니다.");
			location.href="./freeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
		}
		
		if(user_id==dataInfo.M_ID){
			$(".toUdateQB").show();
			$(".deleteQB").show();
		}
		
		if(isAdmin==true){
			$(".deleteQB").show();
		}
		
		//댓글 목록 출력
		answerShowQB(seq,user_id);		
		
		//Q&A 수정화면으로 이동
		$(".toUdateQB").on("click", function(){
			location.href="./updateQB.do?seq="+seq+"&nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
		});
				
		//Q&A 삭제
		$(".deleteQB").on("click", function(){
			if (confirm("정말로 삭제하시겠습니까?")){
				dataInfo=null;
				dataInfo=getAjax("./deleteQB.json",json);

				if (dataInfo.success=="Y"){
					alert("Q&A이 삭제되었습니다.")
					location.href="./qnaBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
				} else {
					alert("Q&A이 삭제되지 못했습니다.");
				}
			}
		});		
		
		//Q&A 답변 입력
		$("#commentBtnQB").on("click", function(){
			var cJson={};
			cJson.seq=seq;
			cJson.content=$(".co_content").html();	
			cJson.date = nowDate();
						
			var data=null;
			data=getAjax("./answerInsertQB.json",cJson);
			if(data.success=="Y"){
				alert("댓글이 성공적으로 작성되었습니다");
				$(".co_content").empty();
				answerShowQB(seq,user_id);
			} else{
				alert("오류가 발생했습니다.")
			}		
		});
			
		// Q&A 목록으로 돌아가기
		$(".btnToQB").on("click", function(){
			location.href="./qnaBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
		});
	});
	
	//Q&A 답변 조회
	function answerShowQB(seq,user_id){	
		var jsonL={};
		jsonL.seq=seq;
		
		var data={};
		data=getAjax("./answerShowQB.json",jsonL).list;
		
		$(".commentText").empty();
		
		var html = "";
		if(data[0]==null){
			
			html += html += "<tr><td>관리자";
			html +="</td><td style='color:red;'>관리자의 답변을 기다려 주세요";
			html +="</td><td></td>";		
			
			html +="</tr>";
			if(isAdmin==true){
				$("#qnaAnswerDiv").show();
			}			
		} else {
		
			html += "<tr><td class='co_id_colum'>관리자";
			html +="</td><td class='co_content_colum'>"+data[0].QB_ANSWER;
			html +="</td><td class='co_date_colum'>"+data[0].QB_ANSWER_DATE+"</td>";		
				
			if(isAdmin==true){
				html +="<td><button class='co_btn_colum commentDelete'>삭제</button></td>";
			}
			html +="</tr>";
			
			$("#qnaAnswerDiv").hide();
		}
							
		$(".commentText").html(html);	
		
		//답변 삭제
		$(".commentDelete").on("click", function(){
			var jsonD={};
			jsonD.seq=seq;

			var data={};
			data=getAjax("/deleteAnswer.json",jsonD);
			if(data.success=="Y"){
				alert("댓글이 삭제되었습니다.");
				answerShowQB(seq,user_id);
			} else{
				alert("댓글이 삭제되지 않았습니다.");
			}
		});
	}
	
</script>

<div style="padding:100px 20%; min-height:600px;">
	
	<!-- Q&A 내용 출력부분-->
	<div style="height:60px;">
		<div id="qbReadTitle" style="font-size:30px;"></div>
		<div id="qbReadWriter" style="float:left; font-size:20px; color:brown"></div>
	</div>
	<hr>
	<div style="height:50px">
		<div style="height:40px;float:right;">	
			<div style="float:left; font-size:20px; color:gray;">
				<div id="qbInsertDate"></div>
				<div id="qbUpdateDate"></div>
			</div>
		</div>
	</div>	
	<div style="padding-top:20px; min-height:400px;">
		<div id="qbReadContent" style="font-size:20px;"></div>
	</div>	
	
	<!-- 답변 -->
	<h5  style="margin-top:20px;">답변</h5>
	<div>
		<table>
			<tbody  class="commentText">
			</tbody>
		</table>
	</div>
	<!-- 관리자나  회원만 볼수 있는 버튼 -->
	<sec:authorize access="hasAnyRole('ROLE_MEMBER','ROLE_ADMIN')">	
	
		<!-- Q&A 답변 입력부분 -->
		<div id="qnaAnswerDiv" style="display:none;">
			<div style="overflow:auto;display: flex;">
				<div contenteditable="true" class="co_content" style="width:80%; min-height:50px; border:1px solid black; float:left" placeholder="내용을 입력해 주세요."></div>
				<div id="commentBtnQB" class="btn btn-toggle" style="display: flex; align-items: center; justify-content: center; border:1px solid black;">완료</div>
			</div>
		</div>
		<!-- Q&A 수정/삭제 버튼+목록으로 돌아가기 버튼 -->
		<div>
			<div id="qbBtnBox" style="float:left;">
				<button class="btn toUdateQB" style="display:none;">수정</button>
				<button class="btn deleteQB" style="display:none;">삭제</button>
			</div>
		</div>
	</sec:authorize>
	<div>	
		<button class="btn btnToQB">돌아가기</button>
	</div>
</div>



