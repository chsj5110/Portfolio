<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<%@ taglib prefix="sec"
    uri="http://www.springframework.org/security/tags"%>
    
    
<style>
	img{
		width:100%;
	}
</style>    
<script>
	var isAdmin=null;
	
	$(document).ready(function() {
		var seq="${seq}"
		
		isAdmin=${isAdmin}
		
		var json= {};
		json.seq=seq;
		
		var dataInfo=null;
		dataInfo=getAjax("./readNB.json",json).data;
		
		if (dataInfo.NB_OPENCHK=='Y'||isAdmin==true) {
		
			$("#nbReadTitle").html(dataInfo.NB_TITLE);
		
			$("#nbReadWriter").html(dataInfo.M_ID);
			$("#nbInsertDate").html(dataInfo.NB_CREATEDATE+" ���");
			$("#nbUpdateDate").html(dataInfo.NB_UPADATEDATE+" ����");
		
			$("#nbReadContent").html(dataInfo.NB_CONTENT);
		
		} else {
			alert("����� �Խñ� �Դϴ�.");
			location.href="./freeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
		}
		
		
		//������ ����ȭ������ �̵�
		$(".toUdateNB").on("click", function(){
			location.href="./adminUpdateNB.do?seq="+seq+"&nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}";
		});
		
		
		//�����ۻ���
		$(".deleteNB").on("click", function(){
			if (confirm("������ �����Ͻðڽ��ϱ�?")){
				dataInfo=null;
				dataInfo=getAjax("./deleteNB.json",json);

				if (dataInfo.success=="Y"){
					alert("�Խñ��� �����Ǿ����ϴ�.")
					location.href="./noticeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}";
				} else {
					alert("�Խñ��� �������� ���߽��ϴ�.");
				}
			}
		});		

		//�������� ������� �̵�
		$(".btnToNB").on("click", function(){
			location.href="./noticeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}";
		});
	});
	
</script>
<div class="content">
	<div style="padding:100px 20%; min-height:600px;">
		<div style="height:60px;">
			<div id="nbReadTitle" style="font-size:30px;"></div>
			<div id="nbReadWriter" style="float:left; font-size:20px; color:brown"></div>
		</div>
		
		<hr>
		
		<div style="height:50px">
			<div style="height:40px;float:right;">	
				<div style="float:left; font-size:20px; color:gray;">
					<div id="nbInsertDate"></div>
					<div id="nbUpdateDate"></div>
				</div>
			</div>
		</div>
		
		<div style="padding-top:20px; min-height:400px;">
			<div id="nbReadContent" style="font-size:20px;"></div>
		</div>	
							
		<sec:authorize access="hasRole('ROLE_ADMIN')">					
			<div id="fbBtnBox" style="float:left;">
				<button  class="btn toUdateNB">����</button>
				<button class="btn deleteNB">����</button>
			</div>
		</sec:authorize>
		<div>
			<button class="btn btnToNB">���ư���</button>
		</div>
	</div>
</div>


