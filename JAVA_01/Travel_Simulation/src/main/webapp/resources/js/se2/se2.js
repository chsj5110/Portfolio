/**
 * 스마트에디터2 스크립트 파일
 */
	var oEditors = []; 
	nhn.husky.EZCreator.createInIFrame({ oAppRef : oEditors, elPlaceHolder : "smartEditor", 
		//저는 textarea의 id와 똑같이 적어줬습니다. 
		sSkinURI : "/../../resources/se2/SmartEditor2Skin.jsp", 
		//경로를 꼭 맞춰주세요! 
		fCreator : "createSEditor2", htParams : { 
			// 툴바 사용 여부 (true:사용/ false:사용하지 않음) 
			bUseToolbar : true,
			// 입력창 크기 조절바 사용 여부 (true:사용/ false:사용하지 않음) 
			bUseVerticalResizer : false, 
			// 모드 탭(Editor | HTML | TEXT) 사용 여부 (true:사용/ false:사용하지 않음) 
			bUseModeChanger : false 
			} 
	}); 
	

	
