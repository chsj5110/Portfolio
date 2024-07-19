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
		
		//��ȸ�� �Խñ� ���
		var dataInfo=null;
		dataInfo=getAjax("./readFB.json",json).data;
		
		if (dataInfo.FB_OPENCHK=='Y'||user_id==dataInfo.M_ID||isAdmin==true) {
		
			$("#fbReadTitle").html(dataInfo.FB_TITLE);
			
			$("#fbReadWriter").html(dataInfo.M_ID);
			$("#fbInsertDate").html(dataInfo.FB_CREATEDATE+" ���");
			$("#fbUpdateDate").html(dataInfo.FB_UPADATEDATE+" ����");	
			$("#fbReadContent").html(dataInfo.FB_CONTENT);
			$("#fbViews").html("��ȸ�� "+dataInfo.FB_VIEWS);

		} else {
			alert("����� �Խñ� �Դϴ�.");
			location.href="./freeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
		}
	
		
		if(user_id==dataInfo.M_ID){
			$(".toUdateFB").show();
			$(".deleteFB").show();
		}
		
		if(isAdmin==true){
			$(".deleteFB").show();
		}
		
		
		//��� ��� ���
		commentListFB(seq,user_id);
		
		
		//�Խñ� ����ȭ������ �̵�
		$(".toUdateFB").on("click", function(){
			location.href="./updateFB.do?seq="+seq+"&nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
		});
		
		
		//�Խñ� ����
		$(".deleteFB").on("click", function(){
			if (confirm("������ �����Ͻðڽ��ϱ�?")){
				dataInfo=null;
				dataInfo=getAjax("./deleteFB.json",json);

				if (dataInfo.success=="Y"){
					alert("�Խñ��� �����Ǿ����ϴ�.")
					location.href="./freeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
				} else {
					alert("�Խñ��� �������� ���߽��ϴ�.");
				}
			}
		});		
		
		//����Է�
		$("#commentBtnFB").on("click", function(){
			var cJson={};
			cJson.fb_seq=seq;
			cJson.content=$(".co_content").html();	
			cJson.date = nowDate();
						
			var data=null;
			data=getAjax("./insertCommentFB.json",cJson);
			if(data.success=="Y"){
				alert("����� ���������� �ۼ��Ǿ����ϴ�");
				$(".co_content").empty();
				commentListFB(seq,user_id);
			} else{
				alert("������ �߻��߽��ϴ�.")
			}		
		});
		

		
		//�Խñ� ������� ���ư���
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
		
		//��� ����
		$(".commentDelete").on("click", function(){
			var jsonD={};
			jsonD.seq=$(this).attr('value');
			jsonD.fb_seq=seq;

			var data={};
			data=getAjax("/deleteComment.json",jsonD);
			if(data.success=="Y"){
				alert("����� �����Ǿ����ϴ�.");
				commentListFB(seq,user_id);
			} else{
				alert("����� �������� �ʾҽ��ϴ�.");
			}
		});
	}
	



	
</script>

<div style="padding:100px 5%; min-height:600px;">
	
	<!-- �Խñ� ���� ��ºκ�-->
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
	
	
	<!-- ��� -->
	<h5  style="margin-top:20px;">���</h5>
	<div>
		<table>
			<tbody  class="commentText">
			</tbody>
		</table>
	</div>
	<!-- �����ڳ�  ȸ���� ���� �ִ� ��ư -->
	<sec:authorize access="hasAnyRole('ROLE_MEMBER','ROLE_ADMIN')">	
		<div style="overflow:auto;display: flex;">
			<div contenteditable="true" class="co_content" placeholder="������ �Է��� �ּ���."></div>
			<div id="commentBtnFB" class="btn btn-toggle" style="display: flex; align-items: center; justify-content: center; border:1px solid black;">�Ϸ�</div>
		</div>
		
		<!-- �Խñ� ����/���� ��ư+������� ���ư��� ��ư -->
		<div>
			<div id="fbBtnBox" style="float:left;">
				<button class="btn toUdateFB" style="display:none;">����</button>
				<button class="btn deleteFB" style="display:none;">����</button>
			</div>
		</div>
	</sec:authorize>
	<div>	
		<button class="btn btnToFB">���ư���</button>
	</div>
</div>



