package a.a.a.dao;

import java.util.ArrayList;
import java.util.HashMap;

import org.springframework.stereotype.Repository;

import a.a.a.dao.AbstractDAO;
import a.a.a.util.PagingVO;

@Repository("noticeBoardDAO")
public class NoticeBoardDAO extends AbstractDAO{
	
	//전체 게시글 목록
	public ArrayList<HashMap<String, Object>> NBList() {
		return (ArrayList<HashMap<String, Object>>) selectList("nbSQL.nbList"); // mapper의 이름과 아이디
	}

	//게시글 등록
	public void insertNB(HashMap<String, Object> hm) {
		insert("nbSQL.nbInsert", hm); 
	}

	//게시글 조회
	public HashMap<String, Object> readNB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (HashMap<String, Object>) selectOne("nbSQL.nbRead",hm);
	}
	
	//게시글 수정
	public void updateNB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("nbSQL.nbUpdate", hm);
	}
	
	//게시글 삭제
	public void deleteNB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("nbSQL.nbDelete", hm);
	}
	
	//전체 게시글 수
	public int countNB() {
		// TODO Auto-generated method stub
		return (int) selectOne("nbSQL.countNB");
	}
	
	
	//페이징 처리후 게시글 목록 출력
	public ArrayList<HashMap<String, Object>> selectNB(PagingVO vo) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("nbSQL.selectNB",vo);
	}
}
