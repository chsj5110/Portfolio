<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8" trimDirectiveWhitespaces="true"%>




<style>

		label{
			color: lightskyblue;
		}
		.modal-content{
			margin-top: 56px;
			text-align:center;
			padding: 10%;
		
		}
		.modal-body{
			/* max-width:600px; */
			padding: 4% 5%;
		    width: 80%;
		    left: 10%;
		}
		.form-group{
			text-align: left;
		}

		@media (min-width: 780px){ 
			.bodySide{
				width: 15%;
			}
			.modal-body{
			padding: 4% 15%;
			}
			.bodyCenter{
				width: 60%;
			}

	 	}  
		
 	 	@media (min-width: 1000px){ 
			.bodySide{
				width: 25%;
			}
			.modal-body{
				padding: 4% 15%;
			}
			.bodyCenter{
				width: 50%;
			}
	 	}  
	 	
	 	@media (max-width: 450px){
	 		a{
	 			font-size:0.8em;
	 		}
	 	}
		.iDiv{
			float:left;
		}	 	

</style>

<script>

$(document).ready(function() {
	
	
	var searchInfo=null;
	var inputChk=0;
	
	//아이디 찾기를 눌렀을때
	$("#showIdSearch").on("click", function(){
		searchInfo="userId";
		$("#userInfoSearchDiv").show();
		$("#userIdSearchDiv").show();
		$("#userPwSearchDiv").hide();
	});
	
	//비밀번호 찾기를 눌렀을때
	$("#showPwSearch").on("click", function(){
		searchInfo="userPw";
		$("#userInfoSearchDiv").show();
		$("#userPwSearchDiv").show();
		$("#userIdSearchDiv").hide();
	});	
	
	//인증키 발송 버튼을 눌렀을때
	$("#authKeySend_btn").on('click',function(){
		alert("인증메일을 확인중입니다. 잠시만 기다려 주세요");
		var json= {};
		json.userEmail = $("#userEmail").val();
		
		var data=null;

		data=getAjax("./emailConfirmSearch.json",json);

		if(data.success=='N'){
			alert("등록되지 않은 이메일입니다.");
		} else {
			alert("인증메일이 발송되었습니다.");
			$("#authKeyConfirm").show();		
		}			
	});
	
	$("#authKeyConfirm_btn").on('click',function(){
		var json= {};
		json.userEmail = $("#userEmail").val();
		json.authKey = $("#inputAuthKey").val();
		
		var data=null;
		data=getAjax("./authKeyConfirm.json",json)

		if(data.success=='N'){
			alert("인증키가 틀렸습니다");
		} else {
			alert("인증완료");
			$("#userInfoSearchDiv").hide();

			if(searchInfo=="userId"){
				$("#showUserIdDiv").show();				
				var dataId = null;
				dataId=getAjax("./membershipIdSelect.json",json).data;				
				$("#showUserId").html(dataId.M_ID);				
			} else if(searchInfo=="userPw"){
				$("#ChangeUserPwDiv").show();
			}			
		}			
	});
	
	$("#showUserIdDivOk").on("click", function(){
		var userIdInfo=$("#showUserId").html();
		$("#userId").val(userIdInfo);
		$("#showUserIdDiv").hide();
	});
	
	
	$("#changePw, #changePwRe").on("keyup", function() {
		var userPw = $("#changePw").val();
		var passRe = $("#changePwRe").val();
		var charP = [];
		for (i = 0; i < userPw.length; i++) {
			charP[i] = userPw.substring(i, i + 1);
		}
		if (charP.length <= 8) {
			$("#passChk").html("9자이상으로 설정해주세요").css(
					"color", "red");
			inputChk = 1;
			return false;
		} else if (passRe !== userPw) {
			$("#passChk").html("비밀번호가 일치하지 않습니다.")
					.css("color", "red");
			inputChk = 1;
			return false;
		} else {
			$("#passChk").html("사용가능합니다").css("color", "blue");
			inputChk = 2;
		}
	});
	
	$("#ChangeUserPwDivOk").on("click", function(){
		
		if (inputChk==2){
			var json={};
			json.userPw = $("#changePw").val();
			json.userEmail = $("#userEmail").val()
			
			var data=null
			data=getAjax("./changePW.json",json);
			
			if (data.success=="Y"){
				alert("비밀번호를 변경했습니다. 다시 로그인해 주세요.");
				location.reload();
			} else {
				alert("비밀번호 변경에 실패했습니다.");
			}
		} else {
			alert("입력양식이 잘못되었습니다.");
		}
	});
	
});
</script>


	<div id="content">

		<!-- Modal content-->
		<div class="modal-content">

			<div class="modal-body">
				<h4>로그인을 해주세요</h4>
				<form role="form" method="post" action="./login">
					<div class="form-group">
						<label class="loginLabel" for="id"> ID :</label> <input type="text"
							class="form-control" id="userId" name="username" placeholder="Enter ID"
							required="required">
					</div>
					<div class="form-group">
						<label class="loginLabel" for="pw"> Password :</label> <input type="password"
							class="form-control" id="userPw" name="password"
							placeholder="Enter Password" required="required">
					</div>
					
					<button type="submit" class="btn btn-default btn-block" style="border: 1px solid #ced4da;"name="submit">Login</button>
					<input name="${_csrf.parameterName}" type="hidden" value="${_csrf.token}" />
				</form>	
				<div>
					<div class="iDiv"><a href=# id="showIdSearch">아이디 찾기</a>&nbsp;|&nbsp;</div>

					<div class="iDiv"><a href=# id="showPwSearch">비밀번호 찾기</a>&nbsp;|&nbsp;</div>

					<div class="iDiv"><a href= "./memberShipMove.do">회원가입</a></div>
				</div>

				<div id="userInfoSearchDiv" style="display:none;">
					<div>
						<div id="userIdSearchDiv" style="diplay:none;"><label for="userEmail1">아이디 찾기</label></div>
						<div id="userPwSearchDiv" style="diplay:none;"><label for="userEmail1">비밀번호 찾기</label></div>
						<div  style="padding-bottom: 10px;">
							<input type="text" id="userEmail" class="form-control keyword" value="" placeholder="이메일">
							<button id="authKeySend_btn" class="btn btn-primary" style="margin-top:1em;">인증키 발송
							</button>
						</div>
						<div id="authKeyConfirm" style="display:none;">
							<div><label for="inputAuthKey">인증키 입력</label></div>
							<div><input id="inputAuthKey" type="text"><button id="authKeyConfirm_btn">확인</button></div>
						</div>
					</div>
				</div>
				
				<div id="showUserIdDiv" style="display:none;">
					<div>당신의 아이디는</div>
					<div id="showUserId" style="color:brown;"></div>
					<button id="showUserIdDivOk" >확인</button>
				</div>
				
				<div id="ChangeUserPwDiv" style="display:none;">
					<div>새로 사용할 비밀번호를 입력해 주세요</div>
					<div>비밀번호 변경<input type="password" id="changePw" value=""></div>
					<div>비밀번호 확인<input type="password" id="changePwRe" value=""></div>
					<div id="passChk"></div>
					<button id="ChangeUserPwDivOk" >확인</button>					
				</div>			
			</div>
			<!-- <div class="modal-footer"></div> -->
		</div>

	</div>
