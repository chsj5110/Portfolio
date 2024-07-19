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
		
		var json= {};
		json.seq=seq;
		
		
		user_id="${userId}"
		isAdmin=${isAdmin}
		
		//조회한 게시글 출력
		var dataInfo=null;
		dataInfo=getAjax("./readFB.json",json).data;
		
		if (dataInfo.FB_OPENCHK=='Y'||user_id==dataInfo.M_ID||isAdmin==true) {
		
			$("#fbReadTitle").html(dataInfo.FB_TITLE);
			
			$("#fbReadWriter").html(dataInfo.M_ID);
			$("#fbInsertDate").html(dataInfo.FB_CREATEDATE+" 등록");
			$("#fbUpdateDate").html(dataInfo.FB_UPADATEDATE+" 수정");	
			$("#fbReadContent").html(dataInfo.FB_CONTENT);
			$("#fbViews").html("조회수 "+dataInfo.FB_VIEWS);

		} else {
			alert("비공개 게시글 입니다.");
			location.href="./freeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
		}
	
		
		if(user_id==dataInfo.M_ID){
			$(".toUdateFB").show();
			$(".deleteFB").show();
		}
		
		if(isAdmin==true){
			$(".deleteFB").show();
		}
		
		
		//댓글 목록 출력
		commentListFB(seq,user_id);
		
		
		//게시글 수정화면으로 이동
		$(".toUdateFB").on("click", function(){
			location.href="./updateFB.do?seq="+seq+"&nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
		});
		
		
		//게시글 삭제
		$(".deleteFB").on("click", function(){
			if (confirm("정말로 삭제하시겠습니까?")){
				dataInfo=null;
				dataInfo=getAjax("./deleteFB.json",json);

				if (dataInfo.success=="Y"){
					alert("게시글이 삭제되었습니다.")
					location.href="./freeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
				} else {
					alert("게시글이 삭제되지 못했습니다.");
				}
			}
		});		
		
		//댓글입력
		$("#commentBtnFB").on("click", function(){
			var cJson={};
			cJson.fb_seq=seq;
			cJson.content=$(".co_content").html();	
			cJson.date = nowDate();
						
			var data=null;
			data=getAjax("./insertCommentFB.json",cJson);
			if(data.success=="Y"){
				alert("댓글이 성공적으로 작성되었습니다");
				$(".co_content").empty();
				commentListFB(seq,user_id);
			} else{
				alert("오류가 발생했습니다.")
			}		
		});
		

		
		//게시글 목록으로 돌아가기
		$(".btnToFB").on("click", function(){
			location.href="./freeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
			
		});
	});
	
	function commentListFB(seq,user_id){	
		var jsonL={};
		jsonL.seq=seq;
		
		var data={};
		data=getAjax("/commentListFB.json",jsonL).list;
		
		$(".commentText").empty();
		
		var html = "";
		for(i=0; i<data.length; i++){
			html += "<tr><td class='co_id_colum'>"+data[i].M_ID;
			html +="</td><td class='co_content_colum'>"+data[i].C_CONTENT;
			html +="</td><td class='co_date_colum'>"+data[i].C_CREATEDATE+"</td>";		
			

			
			if(data[i].M_ID==user_id || isAdmin==true){
				html +="<td><button class='co_btn_colum commentDelete' value='"+data[i].C_SEQ+"'>x</button></td>";
			}
			html +="</tr>";		
		}			
		$(".commentText").html(html);	
		
		//댓글 삭제
		$(".commentDelete").on("click", function(){
			var jsonD={};
			jsonD.seq=$(this).attr('value');
			jsonD.fb_seq=seq;

			var data={};
			data=getAjax("/deleteComment.json",jsonD);
			if(data.success=="Y"){
				alert("댓글이 삭제되었습니다.");
				commentListFB(seq,user_id);
			} else{
				alert("댓글이 삭제되지 않았습니다.");
			}
		});
	}
	



	
</script>

<div style="padding:100px 5%; min-height:600px;">
	
	<!-- 게시글 내용 출력부분-->
	<div style="height:60px;">
		<div id="fbReadTitle" style="font-size:30px;"></div>
		<div id="fbReadWriter" style="float:left; font-size:15px; color:brown"></div>		
	</div>
	<hr>
	<div style="height:50px">
		<div style="height:40px;float:right;">	
			<div style="float:left; font-size:20xp; color:gray;">
				<div id="fbInsertDate"></div>
				<div id="fbUpdateDate"></div>
				<div id="fbViews" style="text-align:right;"></div>
			</div>
		</div>
	</div>	
	<div style="padding-top:50px; min-height:400px;">
		<div id="fbReadContent" style="font-size:20px;"></div>
	</div>	
	
	
	<!-- 댓글 -->
	<h5  style="margin-top:20px;">댓글</h5>
	<div>
		<table>
			<tbody  class="commentText">
			</tbody>
		</table>
	</div>
	<!-- 관리자나  회원만 볼수 있는 버튼 -->
	<sec:authorize access="hasAnyRole('ROLE_MEMBER','ROLE_ADMIN')">	
		<div style="overflow:auto;display: flex;">
			<div contenteditable="true" class="co_content" placeholder="내용을 입력해 주세요."></div>
			<div id="commentBtnFB" class="btn btn-toggle" style="display: flex; align-items: center; justify-content: center; border:1px solid black;">완료</div>
		</div>
		
		<!-- 게시글 수정/삭제 버튼+목록으로 돌아가기 버튼 -->
		<div>
			<div id="fbBtnBox" style="float:left;">
				<button class="btn toUdateFB" style="display:none;">수정</button>
				<button class="btn deleteFB" style="display:none;">삭제</button>
			</div>
		</div>
	</sec:authorize>
	<div>	
		<button class="btn btnToFB">돌아가기</button>
	</div>
</div>



