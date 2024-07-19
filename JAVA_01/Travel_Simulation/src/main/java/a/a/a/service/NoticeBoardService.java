package a.a.a.service;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import a.a.a.util.PagingVO;

public interface NoticeBoardService {
	
	
	//게시글 목록
	public ArrayList NBList() throws SQLException;

	
	//게시글 등록
	public void insertNB(HashMap<String, Object> map) throws SQLException;

	//게시글 조회
	public HashMap<String, Object> readNB(HashMap<String,Object> map) throws SQLException;

	//게시글 수정
	public void updateNB(HashMap<String, Object> hm) throws SQLException;

	//게시글 삭제
	public void deleteNB(HashMap<String, Object> hm) throws SQLException;

	
	//게시글 페이징 처리후 목록 출력
	public ArrayList<HashMap<String, Object>> selectNB(PagingVO vo) throws SQLException;

	//게시글 개수 카운팅
	public int countNB() throws SQLException;

}
