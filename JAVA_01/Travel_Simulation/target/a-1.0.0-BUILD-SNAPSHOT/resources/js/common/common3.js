/**
 * 
 */
/**
 * 2020. 04. 24. 공통 javascript 생성 
 */

/*
 * url 		: 사용할 경로 값
 * json 	: Ajax에 보내줄 JSON 데이터 값
 * datainfo	: SUCCESS에서 가져온 데이터 값
 */
function getAjax(url, json){
	var datainfo = null;
	$.ajax({
		type: "POST",
		url : url,
		data: JSON.stringify(json),
		dataType:"json",
		async : false,
		contentType: 'application/json; charset:utf-8',
		success : function(data) {
			console.log("data : "+ data);
			datainfo = data;
		},
		error: function(jqXHR, textStatus, errorThrown) {
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


function getHtml(url){
	var datainfo = null;

	$.ajax({
		type : "POST",
		url : url,
		dataType : "html",
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



