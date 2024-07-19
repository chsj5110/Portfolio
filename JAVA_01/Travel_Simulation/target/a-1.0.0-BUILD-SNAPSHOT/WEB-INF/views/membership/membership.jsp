<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="sec"
    uri="http://www.springframework.org/security/tags"%>
<style>
		.title {
			width: 600px;
			border-style: groove;
			padding: 30px;
			margin-top: 2rem;
		}
		
		.tag {
			text-align: center;
		}
		
		.zipCode {
			width: 77px;
		}
		
		.juso1,.juso2 {
			width: 300px;
		}
		
		@media (min-width: 760px){ 
			.bodySide {
				width: 15%;
			}
			.modal-body {
			padding: 4% 15%;
			}
			.bodyCenter {
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
</style>
<script>
	var isMember=null;
	var isAdmin=null;
	
	$(document).ready( function() {
				
				isAdmin=${isAdmin}
				isMember=${isMember}
								
				if(isMember==true || isAdmin==true){
				
					$("#addMembership").remove();
					$("#inputMembershipId").remove();
					$("#inputMembershipEmail").remove();	
					
					$("#modifyMembership").show();
					
					var json={};
					
					var dataInfo=null;
					dataInfo=getAjax("./memberShipSelect.json",json);
					
					var Info=null;
					Info=dataInfo.data;
					$("#name").val(Info.M_NAME);
					$("#userEmail").val(Info.M_EMAIL);
					$("#travel_interest").val(Info.M_INTEREST);
					
					$("#btnmembershipUpdate").show();
					$("#btnmembership").hide();
				}	

				
				var idChk = 0;  	//아이디 중복 확인
				var inputChk = 0;	//입력양식 확인
				var emailChk = 0;	//이메일 인증

				
				function notAllow(id) {
					$(id).show().text("허용할수 없는 값이 존재함").css("color", "red");
					inputChk = 1;
				}

				function allow(id) {
					$(id).show().text("사용가능한 양식입니다").css("color", "blue");
					inputChk = 2;
				}
				

				//아이디 중복 확인
				$("#idBtn").on("click", function() {

					var jsonUserId = {};

					jsonUserId.userId = $("#userId").val();
					var dataInfo=null;
					dataInfo=getAjax("./memberSearch.json",jsonUserId)
					
					if(dataInfo.success=='Y'){
						if (dataInfo.bol == true) {
							idChk = 1;
							alert("이미 존재하는 아이디 입니다.");
						} else {
							idChk = 2;
							alert("사용 가능한 아이디입니다");
						}
					} else {
						alert("아이디를 확인할 수 없습니다.");
					}
				});

				//아이디 양식 체크
				$("#userId").keyup(
						function() {
							idChk = 0;
							var userId = $("#userId").val();
							var charStr = [];
							for (i = 0; i < userId.length; i++) {
								charStr[i] = userId.substring(i, i + 1);/*userId의 문자열 추출. substring(a,b)는 a번에서 b-1번까지의 문자를 추출*/
							}
							for (i = 0; i < charStr.length; i++) {
								if (charStr[i] >= "a" && charStr[i] <= "z") {
									allow("#userChk");
								} else if (charStr[i] >= "A"
										&& charStr[i] <= "Z") {
									allow("#userChk");
								} else if (charStr[i] >= 0 && charStr[i] <= 9) {
									allow("#userChk");
								} else if (charStr[i] == "_") {
									allow("#userChk");
								} else {
									notAllow("#userChk");
									return false;
								}
							}
							if (charStr.length <= 5) {
								$("#userChk").show().text("6자이상으로 설정해주세요").css(
										"color", "red");
								inputChk = 1;
								return false;
							}
						});

				$("#userPw, #passRe").keyup(
						function() {
							var userPw = $("#userPw").val();
							var passRe = $("#passRe").val();
							var charP = [];
							for (i = 0; i < userPw.length; i++) {
								charP[i] = userPw.substring(i, i + 1);
							}
							if (charP.length <= 8) {
								$("#passChk").show().text("9자이상으로 설정해주세요").css(
										"color", "red");
								inputChk = 1;
								return false;
							} else if (passRe !== userPw) {
								$("#passChk").show().text("비밀번호가 일치하지 않습니다.")
										.css("color", "red");
								inputChk = 1;
								return false;
							} else {
								allow("#passChk");
							}
						});

				//이름 양식 체크
				$("#name").keyup(
						function() {
							var name = $("#name").val();
							var charN = [];
							for (i = 0; i < name.length; i++) {
								charN[i] = name.substring(i, i + 1);
							}
							for (i = 0; i < charN.length; i++) {
								if (charN[i] >= "a" && charN[i] <= "z") {
									allow("#nameChk");
								} else if (charN[i] >= "A" && charN[i] <= "Z") {
								} else if (charN[i] >= "ㄱ" && charN[i] <= "힣") {
								} else {
									notAllow("#nameChk");
									return false;
								}
							}
							if (charN.length <= 2) {
								$("#nameChk").show().text("3자이상으로 설정해주세요").css(
										"color", "red");
								inputChk = 1;
								return false;
							} else {
								allow("#nameChk");
							}
						});
				
				//이메일 인증
				$("#userEmail1, #userEmail2").on('keyup',function(){
					emailChk = 1;
				});
				
				$("#email_certification_btn").on('click',function(){
					alert("인증메일을 보내고 있습니다. 잠시만 기다려 주세요");
					var json= {};
					json.userEmail = $("#userEmail").val();
					
					var dataInfo=null
					dataInfo=getAjax("./emailConfirm.json",json);

					if(dataInfo.success=='E'){
						alert("이미 가입된 메일입니다.");
					} else if (dataInfo.success=='N') {
						alert("잘못된 입력양식입니다.");
					} else {
						alert("인증메일이 발송되었습니다.");
						$("#certification_key").show();
					}						
				});
				
				$("#email_certification_submit_btn").on('click',function(){
					var json= {};
					json.userEmail = $("#userEmail").val();
					json.authKey = $("#input_authKey").val();
					
					var dataInfo=null;
					dataInfo=getAjax( "./authKeyConfirm.json",json);
					
					if(dataInfo.success=='N'){
						alert("인증키가 틀렸습니다");
					} else {
						alert("인증완료");
						emailChk = 2;								
					}			
				});
				
				//회원가입 버튼 클릭시
				$("#btnmembership").on("click", function() {
					if (idChk == 2 && inputChk == 2 && emailChk == 2) {
						var json = {};

						json.userId = $("#userId").val();
						json.userPw = $("#userPw").val();
						json.name = $("#name").val();
						json.userEmail = $("#userEmail").val()
						json.interest = $("#travel_interest").val();
						json.date = nowDate();

						var dataInfo=null;
						dataInfo=getAjax("./memberShipInsert.json",json);

						if(dataInfo.success=='N'){
							alert("회원정보를 입력하지 않았습니다.");
						} else {
							alert("회원가입에 성공했습니다.");
							location.href="./login.do";						
						}	

					} else {
						alert("idChk="+idChk);
						alert("inputChk="+inputChk);
						alert("입력양식이나 아이디 중복 여부를 확인해주세요.")
					}
				});
				
				//수정완료 버튼을 눌렀을때
				$("#btnmembershipUpdate").on("click", function() {
					if (inputChk == 2) {
						if($("#userPw").val() != "" && $("#userPw").val() == $("#passRe").val()) {
							var json = {};
							
							json.userPw = $("#userPw").val();
							json.name = $("#name").val();
							json.interest = $("#travel_interest").val();
							json.date = nowDate();
	
							var dataInfo=null;
							dataInfo=getAjax("./membershipUpdate.json",json);
							if(dataInfo.success=='N'){
								alert("회원정보를 변경하지 못했습니다..");
							} else {
								alert("회원정보가 변경되었습니다..");
								location.href="./main.do";						
							}	
						} else {
							alert("비밀번호를 입력해주십시오.");
						}
					} else {
						alert("idChk="+idChk);
						alert("inputChk="+inputChk);
						alert("입력양식이나 아이디 중복 여부를 확인해주세요.");
					}
				});
				
				//메인화면 이동
				$("#main").click(
						function() {
							location.href="./main.do";
				});
			});
	

</script>

	<div class="title">
		<div>
			<h2 id="addMembership">회원가입</h2>
			<h2 id="modifyMembership" style="display:none;">회원정보 수정</h2>
		</div>
		<hr>
		<div>
			<br> <br>
			<table>
				<tr id="inputMembershipId">
					<td class="tag">아이디</td>
					<td><input type="text" id="userId" value="" placeholder="아이디">
						<input type="button" class="btn1" id="idBtn" value="중복확인">
						<font id="userChk"></font></td>
				</tr>
				<tr>
					<td class="tag">암호</td>
					<td><input type="password" id="userPw" value=""></td>
				</tr>
				<tr>
					<td class="tag">암호확인</td>
					<td><input type="password" id="passRe" value=""> <font
						id="passChk"></font></td>
				</tr>
				<tr>
					<td class="tag">이름</td>
					<td><input type="text" id="name" value="" placeholder="이름">
						<font id="nameChk"></font></td>
				</tr>
				<tr id="inputMembershipEmail">
					<td class="tag">이메일</td>
					<td>
						<input type="text" id="userEmail" value="" placeholder="이메일">
						<button class="btn-primary" id="email_certification_btn">인증키 발송
						</button>
						 <font id="mailChk"></font>
					</td>
				</tr>
				<tr id="certification_key" style="display:none;">
					<td>인증키 입력</td>
					<td><input id="input_authKey" type="text"><button id="email_certification_submit_btn">확인</button></td>
				</tr>

				<tr>
					<td class="tag">여행관심사</td>
					<td><input type="text" class="juso1" id="travel_interest" value=""	placeholder=""><br>
						<font id="jusoChk"></font></td>
				</tr>
			</table>
			<hr>
		</div>
		<div class="btn">
			<input type="button" class="btn1" id="btnmembership" value="회원가입">
			<input type="button" class="btn1" id="btnmembershipUpdate" value="수정완료" style="display:none;">
			<input type="button" class="btn2" id="main" value="메인">
		</div>
	</div>
