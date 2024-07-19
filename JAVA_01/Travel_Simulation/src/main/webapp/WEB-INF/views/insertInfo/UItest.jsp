<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<style>
	body{
		background-color: #555555;
		}
	.wrap{
		background-color: #ffffff;
		margin-left: 100px;
		margin-top: 100px;
	}
	 div.wrap {
            width: 200px;
        }
        div.text-box {
            text-align: center;
        }
        h4 {
            margin: 10px auto 0;
        }
        div.img-box {
            max-height: 100px;
            overflow: hidden;
        }
        img {
            width: 150px;
            margin: -20px auto 0;
        }
        a {
            text-decoration: none;
            color: #000;
        }
.btn_like {
  position: relative;
  display: block;
  width: 44px;
  height: 44px;
  border: 1px solid #e8e8e8;
  border-radius: 44px;
  font-family: notokr-bold,sans-serif;
  font-size: 14px;
  line-height: 16px;
  background-color: #fff;
  color: #DD5D54;
  box-shadow: 0 2px 2px 0 rgba(0,0,0,0.03);
  transition: border .2s ease-out,box-shadow .1s ease-out,background-color .4s ease-out;
  cursor: pointer;
}

.btn_like:hover {
  border: 1px solid rgba(228,89,89,0.3);
  background-color: rgba(228,89,89,0.02);
  box-shadow: 0 2px 4px 0 rgba(228,89,89,0.2);
}

.btn_unlike .img_emoti {
    background-position: -30px -120px;
}

.img_emoti {
    display: inline-block;
    overflow: hidden;
    font-size: 0;
    line-height: 0;
    background: url(https://mk.kakaocdn.net/dn/emoticon/static/images/webstore/img_emoti.png?v=20180410) no-repeat;
    text-indent: -9999px;
    vertical-align: top;
    width: 20px;
    height: 17px;
    margin-top: 1px;
    background-position: 0px -120px;
    text-indent: 0;
}
    </style>
    <script  src="http://code.jquery.com/jquery-latest.min.js"></script>
    <script type="text/javascript">
    $(document).ready(function(){
    	$('button').click(function(){
    	  if($(this).hasClass('btn_unlike')){
    	    $(this).removeClass('btn_unlike');
    	     alert("저장취소");
    	  }
    	  else{
    	    $(this).addClass('btn_unlike');
    	    alert("저장");
    	  }
    	});
    });
    </script>
<title>Insert title here</title>
</head>
<body>				
				
				<div class='wrap'>
	           	 <div class='text-box'>
	           	 	<button type="button" class="btn_like">
						<span class="img_emoti">좋아요</span>
					</button>
	          		<h4>어딘가</h4>
	           		<div class='img-box'>
	            		<img src='https://image.shutterstock.com/image-vector/palace-icon-outline-vector-web-260nw-1046855677.jpg'>
	            	</div>  
	            	<a target='_blank' href='https://www.royalpalace.go.kr/'>
	           			<p>홈페이지 방문하기</p>
	            	</a>
	            </div>
	           </div>
	           
	           
	           
</body>
</html>