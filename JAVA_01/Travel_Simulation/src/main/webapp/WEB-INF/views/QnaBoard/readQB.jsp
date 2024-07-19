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
		
		//��ȸ�� Q&A ���
		var dataInfo=null;
		dataInfo=getAjax("./readQB.json",json).data;
		
		if (dataInfo.QB_OPENCHK=='Y'||user_id==dataInfo.M_ID||isAdmin==true) {
		
			$("#qbReadTitle").html(dataInfo.QB_TITLE);
		
			$("#qbReadWriter").html(dataInfo.M_ID);
			$("#qbInsertDate").html(dataInfo.QB_CREATEDATE+" ���");
			$("#qbUpdateDate").html(dataInfo.QB_UPADATEDATE+" ����");	
			$("#qbReadContent").html(dataInfo.QB_CONTENT);
		
		
		} else {
			alert("����� �Խñ� �Դϴ�.");
			location.href="./freeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
		}
		
		if(user_id==dataInfo.M_ID){
			$(".toUdateQB").show();
			$(".deleteQB").show();
		}
		
		if(isAdmin==true){
			$(".deleteQB").show();
		}
		
		//��� ��� ���
		answerShowQB(seq,user_id);		
		
		//Q&A ����ȭ������ �̵�
		$(".toUdateQB").on("click", function(){
			location.href="./updateQB.do?seq="+seq+"&nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
		});
				
		//Q&A ����
		$(".deleteQB").on("click", function(){
			if (confirm("������ �����Ͻðڽ��ϱ�?")){
				dataInfo=null;
				dataInfo=getAjax("./deleteQB.json",json);

				if (dataInfo.success=="Y"){
					alert("Q&A�� �����Ǿ����ϴ�.")
					location.href="./qnaBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
				} else {
					alert("Q&A�� �������� ���߽��ϴ�.");
				}
			}
		});		
		
		//Q&A �亯 �Է�
		$("#commentBtnQB").on("click", function(){
			var cJson={};
			cJson.seq=seq;
			cJson.content=$(".co_content").html();	
			cJson.date = nowDate();
						
			var data=null;
			data=getAjax("./answerInsertQB.json",cJson);
			if(data.success=="Y"){
				alert("����� ���������� �ۼ��Ǿ����ϴ�");
				$(".co_content").empty();
				answerShowQB(seq,user_id);
			} else{
				alert("������ �߻��߽��ϴ�.")
			}		
		});
			
		// Q&A ������� ���ư���
		$(".btnToQB").on("click", function(){
			location.href="./qnaBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
		});
	});
	
	//Q&A �亯 ��ȸ
	function answerShowQB(seq,user_id){	
		var jsonL={};
		jsonL.seq=seq;
		
		var data={};
		data=getAjax("./answerShowQB.json",jsonL).list;
		
		$(".commentText").empty();
		
		var html = "";
		if(data[0]==null){
			
			html += html += "<tr><td>������";
			html +="</td><td style='color:red;'>�������� �亯�� ��ٷ� �ּ���";
			html +="</td><td></td>";		
			
			html +="</tr>";
			if(isAdmin==true){
				$("#qnaAnswerDiv").show();
			}			
		} else {
		
			html += "<tr><td class='co_id_colum'>������";
			html +="</td><td class='co_content_colum'>"+data[0].QB_ANSWER;
			html +="</td><td class='co_date_colum'>"+data[0].QB_ANSWER_DATE+"</td>";		
				
			if(isAdmin==true){
				html +="<td><button class='co_btn_colum commentDelete'>����</button></td>";
			}
			html +="</tr>";
			
			$("#qnaAnswerDiv").hide();
		}
							
		$(".commentText").html(html);	
		
		//�亯 ����
		$(".commentDelete").on("click", function(){
			var jsonD={};
			jsonD.seq=seq;

			var data={};
			data=getAjax("/deleteAnswer.json",jsonD);
			if(data.success=="Y"){
				alert("����� �����Ǿ����ϴ�.");
				answerShowQB(seq,user_id);
			} else{
				alert("����� �������� �ʾҽ��ϴ�.");
			}
		});
	}
	
</script>

<div style="padding:100px 20%; min-height:600px;">
	
	<!-- Q&A ���� ��ºκ�-->
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
	
	<!-- �亯 -->
	<h5  style="margin-top:20px;">�亯</h5>
	<div>
		<table>
			<tbody  class="commentText">
			</tbody>
		</table>
	</div>
	<!-- �����ڳ�  ȸ���� ���� �ִ� ��ư -->
	<sec:authorize access="hasAnyRole('ROLE_MEMBER','ROLE_ADMIN')">	
	
		<!-- Q&A �亯 �Էºκ� -->
		<div id="qnaAnswerDiv" style="display:none;">
			<div style="overflow:auto;display: flex;">
				<div contenteditable="true" class="co_content" style="width:80%; min-height:50px; border:1px solid black; float:left" placeholder="������ �Է��� �ּ���."></div>
				<div id="commentBtnQB" class="btn btn-toggle" style="display: flex; align-items: center; justify-content: center; border:1px solid black;">�Ϸ�</div>
			</div>
		</div>
		<!-- Q&A ����/���� ��ư+������� ���ư��� ��ư -->
		<div>
			<div id="qbBtnBox" style="float:left;">
				<button class="btn toUdateQB" style="display:none;">����</button>
				<button class="btn deleteQB" style="display:none;">����</button>
			</div>
		</div>
	</sec:authorize>
	<div>	
		<button class="btn btnToQB">���ư���</button>
	</div>
</div>



