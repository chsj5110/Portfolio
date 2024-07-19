<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>

<!-- security���� ajax ����� �ϱ� ���� meta tag -->
<meta name="_csrf" content="${_csrf.token}">
<meta name="_csrf_header" content="${_csrf.headerName}">

<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<script type="text/javascript"
	src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
<script>
$(document).ready(function() {
	
	//security���� ajax�� ����ϱ� ���� token/header
	var token = $("meta[name='_csrf']").attr("content");
	var header = $("meta[name='_csrf_header']").attr("content");
	$(document).ajaxSend(function(e, xhr, options) {
	    xhr.setRequestHeader(header, token);
	});
	
	
	$("#email_certification_btn").on('click',function(){
		var json= {};
		json.userEmail = $("#userEmail1").val()+ $("#userEmail2").val();
		
		$.ajax({
			type : "POST",
			url : "./emailConfirm.json",
			data : JSON.stringify(json),
			dataType : "json",
			contentType : 'application/json; charset:utf-8',
			success : function(data) {

				if(data.success=='N'){
					alert("�̹� ���Ե� �����Դϴ�.");
				} else {
					alert("���������� �߼۵Ǿ����ϴ�.");
					$("#certification_key").show();
					
				}			
			},
			error : function(jqXHR, textStatus, errorThrown) {
				console.log(jqXHR.responseText);
				alert("fail");
			}
			
		});
	});
	
	$("#email_certification_submit_btn").on('click',function(){
		var json= {};
		json.userEmail = $("#userEmail1").val()+ $("#userEmail2").val();
		json.authKey = $("#input_authKey").val();
		
		$.ajax({
			type : "POST",
			url : "/authKeyConfirm.json",
			data : JSON.stringify(json),
			dataType : "json",
			contentType : 'application/json; charset:utf-8',
			success : function(data) {

				if(data.success=='N'){
					alert("����Ű�� Ʋ�Ƚ��ϴ�");
				} else {
					alert("�����Ϸ�");
					location.href="./memberShipMove.do";
					
				}			
			},
			error : function(jqXHR, textStatus, errorThrown) {
				console.log(jqXHR.responseText);
				alert("fail");
			}
			
		});
	});
	
});
</script>
<body>


	<div>�̸���</div>
	<div>
		<input type="text" id="userEmail1" value="" placeholder="�̸���">
		<select id="userEmail2">
			<option>@gmail.com</option>
			<option>@naver.com</option>
			<option>@hanmail.net</option>
		</select>
		<button id="email_certification_btn">����Ű �߼�
		</button>
	</div>
	<div id="certification_key" style="display:none;">
		����Ű �Է� <input id="input_authKey" type="text"><button id="email_certification_submit_btn">Ȯ��</button>
	</div>


</body>
</html>