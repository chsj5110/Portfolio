package a.a.a.dao;

import java.util.ArrayList;
import java.util.HashMap;

import org.springframework.stereotype.Repository;

import a.a.a.dao.AbstractDAO;
import a.a.a.util.PagingVO;

@Repository("qnaBoardDAO")
public class QnaBoardDAO extends AbstractDAO{
	
	//Q&A 등록
	public void insertQB(HashMap<String, Object> hm) {
		insert("qbSQL.qbInsert", hm); 
	}

	//Q&A 조회
	public HashMap<String, Object> readQB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (HashMap<String, Object>) selectOne("qbSQL.qbRead",hm);
	}
	
	//Q&A 수정
	public void updateQB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("qbSQL.qbUpdate", hm);
	}
	
	//Q&A 삭제
	public void deleteQB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("qbSQL.qbDelete", hm);
	}

	//Q&A 답변 조회
	public ArrayList<HashMap<String, Object>> answerShowQB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("qbSQL.qbAnswerShow", hm);
	}

	public void answerInsertQB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("qbSQL.qbAnswerInsert", hm); 
	}

	public void deleteAnswer(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("qbSQL.qbAnswerDelete", hm);
	}

	//페이징 처리하여 Q&A 출력
	public ArrayList<HashMap<String, Object>> selectQB(PagingVO vo) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("qbSQL.selectQB",vo);
	}

	//Q&A 게시글 개수 반환
	public int countQB(PagingVO vo) {
		// TODO Auto-generated method stub
		return (int) selectOne("qbSQL.countQB",vo);
	}
}
