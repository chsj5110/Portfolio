<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec"%>
<%@page import="java.util.*" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script>
	alert("denied page!");
	location.herf="./main.do"
</script>
</head>
<body>
	<h1>접근할수 없는 페이지입니다~</h1>
	<img src="/resources/img/accessDenied.gif">
	
	<h3>${SPRING_SECURITY_403_EXCEPTION.getMessage()}</h3>
	<h3>${msg}</h3>
	
	<!-- <a class="btn btn-primary" href="#" onclick="document.getElementById('logout-form').submit();">로그아웃</a> -->
	<form id="logout-form" action='/logout.do' method="POST">
	 	<input name="${_csrf.parameterName}" type="hidden" value="${_csrf.token}"/>
	 	<button class="btn btn-primary" type="submit">로그아웃</button>
	</form>
	
	
	<a href="./main.do">메인화면으로</a>
</body>
</html>