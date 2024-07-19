<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>ReserveSite JSP</title>
	</head>
	<script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.js"></script>
	<script>
	
	</script>
	<style>
		#box1{
			text-align : center;
		} 
		#box2, #box3, #box4 {
			text-align : center;
			color : skyblue;
		}
	</style>
<body>
<br>
	<div id='box1'>
		<h1>예약사이트</h1>
		<h5>로고를 선택하시면 사이트로 바로 이동합니다.</h5>
	</div>
	<br>
	<div id='box2'>
		<h2>&#60;항공&#62;</h2>
		<a href ="https://www.kayak.co.kr/" target="_blank"=><img src="/resources/img/logo/kayak.png" width="200px"></a><br>
		&nbsp <a href="/board_tag.do?tagname=Kayak" style="text-decoration:none; color:black; font-size:10px;">KAYAK 사이트 이용후기 바로가기</a><br><br>
		<a href ="https://www.skyscanner.co.kr/" target="_blank"=><img src="/resources/img/logo/skyscanner.svg" width="200px"></a><br>
		&nbsp <a href="/board_tag.do?tagname=Skyscanner" style="text-decoration:none; color:black; font-size:10px;">SKYSCANNER 사이트 이용후기 바로가기</a>
    </div>
    <br>
    <div id='box3'>
    	<h2>&#60;숙소&#62;</h2>
    	<a href ="https://www.booking.com/" target="_blank"=><img src="/resources/img/logo/bookingdotcom.png" width="200px"></a><br>
    	&nbsp <a href="/board_tag.do?tagname=Booking.com" style="text-decoration:none; color:black; font-size:10px;">BOOKING.COM 사이트 이용후기 바로가기</a><br><br>
    	
    	<a href ="https://www.agoda.com/" target="_blank"=><img src="/resources/img/logo/agoda.png" width="200px"></a><br>
    	&nbsp <a href="/board_tag.do?tagname=Agoda" style="text-decoration:none; color:black; font-size:10px;">AGODA 사이트 이용후기 바로가기</a><br><br>
    	
    	<a href ="https://www.airbnb.co.kr" target="_blank"=><img src="/resources/img/logo/airbnb.png" width="200px"></a><br>
    	&nbsp <a href="/board_tag.do?tagname=Airbnb" style="text-decoration:none; color:black; font-size:10px;">AIR BNB 사이트 이용후기 바로가기</a><br><br>
    	
    	<a href ="https://www.expedia.co.kr/" target="_blank"=><img src="/resources/img/logo/expedia.png" width="200px"></a><br>
    	&nbsp <a href="/board_tag.do?tagname=Expedia" style="text-decoration:none; color:black; font-size:10px;">EXPEDIA 사이트 이용후기 바로가기</a><br><br>
    	
    	<a href ="https://www.hotelscombined.co.kr/" target="_blank"=><img src="/resources/img/logo/hotelscombined.jpg" width="200px"></a><br>
    	&nbsp <a href="/board_tag.do?tagname=Hotelscombined" style="text-decoration:none; color:black; font-size:10px;">HOTELS COMBINED 사이트 이용후기 바로가기</a><br><br>
    	
    	<a href ="https://www.hotels.com/" target="_blank"=><img src="/resources/img/logo/hotelsdotcom.jpg" width="200px"></a><br>
    	&nbsp <a href="/board_tag.do?tagname=Hotels.com" style="text-decoration:none; color:black; font-size:10px;">HOTELS.COM 사이트 이용후기 바로가기</a>
    </div>
    <br>
    <div id='box4'>
    	<h2>&#60;렌트카&#62;</h2>
    	<a href ="https://www.rentalcars.com/" target="_blank"=><img src="/resources/img/logo/rentalcarsdotcom.png" width="200px"></a><br>
    	&nbsp <a href="/board_tag.do?tagname=Rentalcars" style="text-decoration:none; color:black; font-size:10px;">RENTALCARS.COM 사이트 이용후기 바로가기</a><br>
    </div>
    <br>
    <br>
    <br>
 	
</body>
</html>