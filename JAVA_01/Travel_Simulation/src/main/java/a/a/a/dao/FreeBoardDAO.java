package a.a.a.dao;

import java.util.ArrayList;
import java.util.HashMap;

import org.springframework.stereotype.Repository;

import a.a.a.dao.AbstractDAO;
import a.a.a.util.PagingVO;

@Repository("freeBoardDAO")
public class FreeBoardDAO extends AbstractDAO{
	


	//게시글 등록
	public void insertFB(HashMap<String, Object> hm) {
		insert("fbSQL.fbInsert", hm); 
	}

	//게시글 조회
	public HashMap<String, Object> readFB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("fbSQL.fbViews",hm);
		return (HashMap<String, Object>) selectOne("fbSQL.fbRead",hm);
	}
	
	//게시글 수정
	public void updateFB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("fbSQL.fbUpdate", hm);
	}
	
	//게시글 삭제
	public void deleteFB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("fbSQL.fbDelete", hm);
	}
	
	//전체 게시글 수
	public int countFB(PagingVO vo) {
		// TODO Auto-generated method stub
		return (int) selectOne("fbSQL.countFB",vo);
	}
	
	
	//페이징 처리후 게시글 목록 출력
	public ArrayList<HashMap<String, Object>> selectFB(PagingVO vo) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("fbSQL.selectFB",vo);
	}
	
	

}
