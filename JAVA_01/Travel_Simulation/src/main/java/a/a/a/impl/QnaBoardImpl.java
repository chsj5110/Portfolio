package a.a.a.impl;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import a.a.a.dao.QnaBoardDAO;
import a.a.a.service.QnaBoardService;
import a.a.a.util.PagingVO;

@Service("qnaBoardService")
public class QnaBoardImpl implements QnaBoardService{

	
	@Resource(name="qnaBoardDAO")
    private QnaBoardDAO qnaBoardDAO;
	
	//Q&A 등록
	@Override
	public void insertQB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		qnaBoardDAO.insertQB(hm);
	}

	//Q&A 조회
	@Override
	public HashMap<String, Object> readQB(HashMap<String, Object> hm) throws SQLException{
		// TODO Auto-generated method stub
		return (HashMap<String,Object>) qnaBoardDAO.readQB(hm);

	}
	
	//Q&A 수정
	@Override
	public void updateQB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		qnaBoardDAO.updateQB(hm);
	}
	
	//Q&A 삭제
	@Override
	public void deleteQB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		qnaBoardDAO.deleteQB(hm);
	}

	//Q&A 답변 조회
	@Override
	public ArrayList<HashMap<String, Object>> answerShowQB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) qnaBoardDAO.answerShowQB(hm);
	}
	
	//Q&A 답변 등록
	@Override
	public void answerInsertQB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		qnaBoardDAO.answerInsertQB(hm);
	}
	
	
	//Q&A 답변 삭제
	@Override
	public void deleteAnswer(HashMap<String, Object> hm) throws SQLException  {
		// TODO Auto-generated method stub
		qnaBoardDAO.deleteAnswer(hm);
	}

	@Override
	public int countQB(PagingVO vo) throws SQLException {
		// TODO Auto-generated method stub
		return qnaBoardDAO.countQB(vo);
	}

	@Override
	public ArrayList<HashMap<String, Object>> selectQB(PagingVO vo) throws SQLException {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) qnaBoardDAO.selectQB(vo);
	}
	
    
}