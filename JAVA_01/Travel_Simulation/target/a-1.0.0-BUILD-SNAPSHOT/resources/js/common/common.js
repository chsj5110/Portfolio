




/**
 * json을 이용한 ajax 통신
 * @param json          : 사용할 경로 값              
 * @param url           : Ajax에 보내줄 JSON 데이터 값  
 * @returns dataInfo    : SUCCESS에서 가져온 데이터 값   
 */
function getAjax(url,json){
	
	var dataInfo=null;
		  
	var  token = $("meta[name='_csrf']").attr("content");
	var  header = $("meta[name='_csrf_header']").attr("content");
	
	$.ajax({
		type : "POST",
		url : url,
		data : JSON.stringify(json),
		dataType : "json",
        beforeSend: function(xhr) {
            xhr.setRequestHeader(header, token);
        },
		async:false,	//ajax가 처리되기 전에는 다음문장을 실행하지 않음
		contentType : 'application/json; charset:utf-8',
		success : function(data) {
			
			dataInfo=data;		
		},
		error : function(jqXHR, textStatus, errorThrown) {
			console.log(jqXHR.responseText);
			alert("fail");
		}
		
	});
	
	return dataInfo;
}

/**
 * 현재 날짜/시간 반환
 * @returns
 */
function nowDate(){
	var d= new Date();
	var month=d.getMonth()+1;
	var date=d.getDate();
	var hours=d.getHours();
	var minutes=d.getMinutes();
	var seconds=d.getSeconds();
	var nowDate = d.getFullYear()
				+"-"+(month<10 ? "0"+month : month)
				+"-"+(date<10 ? "0"+date : date)
				+" "+(hours<10 ? "0"+hours : hours)
				+":"+(minutes<10 ? "0"+minutes : minutes)
				+":"+(seconds<10 ? "0"+seconds : seconds);
	return nowDate;
}


/**
 * 엔터키일때 지정된 btn을 클릭하는 함수
 * @param btn
 * @returns
 */
function enterkey(btn) {
    if (window.event.keyCode == 13) {
         // 엔터키가 눌렸을 때 검색버튼이 클릭됨
         $(btn).click();
    }
}

/**
 * 페이지의 맨 위로 이동하는 버튼
 * @returns
 */
function goTop(){
	$('html').scrollTop(0);

}
function getHtml(url){
	var datainfo = null;
	var  token = $("meta[name='_csrf']").attr("content");
	var  header = $("meta[name='_csrf_header']").attr("content");

	$.ajax({
		type : "POST",
		url : url,
		dataType : "html",
        beforeSend: function(xhr) {
            xhr.setRequestHeader(header, token);
        },
		async : false,
		contentType : 'application/json; charset:utf-8',
		success : function(data){
			datainfo = data;
		},
		error : function(jqXHR, textStatus, errorThrown){
			console.log(jqXHR.responseText);
		}
	});
	return datainfo;
}

function getPastDate(period){
	var dt = new Date();
	var year = dt.getFullYear();
	var month = dt.getMonth()+1;
	var day = dt.getDate();
	
	if(month < 10) month = "0" + month;
	if(day < 10) day = "0" + day;
	
	return year + "/" + month + "/" + day;
}