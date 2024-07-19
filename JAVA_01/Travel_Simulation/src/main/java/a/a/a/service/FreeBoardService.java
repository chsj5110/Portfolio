package a.a.a.service;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import a.a.a.util.PagingVO;

public interface FreeBoardService {
	
	//게시글 등록
	public void insertFB(HashMap<String, Object> map) throws SQLException;

	//게시글 조회
	public HashMap<String, Object> readFB(HashMap<String,Object> map) throws SQLException;

	//게시글 수정
	public void updateFB(HashMap<String, Object> hm) throws SQLException;

	//게시글 삭제
	public void deleteFB(HashMap<String, Object> hm) throws SQLException;
	
	// 게시물 총 갯수
	public int countFB(PagingVO vo) throws SQLException;

	// 페이징 처리 게시글 조회
	public ArrayList<HashMap<String,Object>> selectFB(PagingVO vo) throws SQLException;;

}
