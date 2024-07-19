<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
		<div>
			<div>
				<h2>회원정보</h2>
			</div>
			<hr>
			<div>
				<br> <br>
				<table>
					<tr>
						<td class="tag">아이디</td>
						<td id="showId"></td>
					</tr>
					<tr>
						<td class="tag">이름</td>
						<td id="showName"></td>
					</tr>
					<tr>
						<td class="tag">이메일</td>
						<td id="showEmail"></td>
					</tr>
					<tr>
						<td class="tag">여행관심사</td>
						<td id="showInterest"></td>
					</tr>
					<tr>
						<td class="tag">북마크</td>
						<td id="showBookmark">
							북마크 보기(새창)
						</td>
					
					</tr>
					<tr>
						<td class="tag">가입일</td>
						<td id="membershipCreateDate"></td>
					</tr>
					<tr style="display:none;" id="memDeleteDiv">
						<td class="tag">탈퇴일</td>
						<td id="membershipDeleteDate"></td>
					</tr>
				</table>
				<hr>
			</div>
			<div class="memBtnSet">
				<button class="btn btn-primary" id="toMembershipUdateBtn">정보수정</button>
				<button class="toMainBtn btn btn-primary">메인</button>
			</div>
		</div>
		<div id="logoutDiv">
			<form id="logout-form" action='/logout.do' method="POST" style="display:none;" onclick="$('#logout-form').submit();">
			 	<input name="${_csrf.parameterName}" type="hidden" value="${_csrf.token}"/>
			 	<button class="btn btn-primary" id="logoutBtn" type="submit">로그아웃</button>
			</form>	
		</div>
		
		
		