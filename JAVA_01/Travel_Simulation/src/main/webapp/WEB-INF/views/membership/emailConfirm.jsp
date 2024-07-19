<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>

<!-- security에서 ajax 통신을 하기 위한 meta tag -->
<meta name="_csrf" content="${_csrf.token}">
<meta name="_csrf_header" content="${_csrf.headerName}">

<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<script type="text/javascript"
	src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
<script>
$(document).ready(function() {
	
	//security에서 ajax를 사용하기 위한 token/header
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
					alert("이미 가입된 메일입니다.");
				} else {
					alert("인증메일이 발송되었습니다.");
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
					alert("인증키가 틀렸습니다");
				} else {
					alert("인증완료");
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


	<div>이메일</div>
	<div>
		<input type="text" id="userEmail1" value="" placeholder="이메일">
		<select id="userEmail2">
			<option>@gmail.com</option>
			<option>@naver.com</option>
			<option>@hanmail.net</option>
		</select>
		<button id="email_certification_btn">인증키 발송
		</button>
	</div>
	<div id="certification_key" style="display:none;">
		인증키 입력 <input id="input_authKey" type="text"><button id="email_certification_submit_btn">확인</button>
	</div>


</body>
</html>