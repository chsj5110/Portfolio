package a.a.a.impl;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import a.a.a.dao.FreeBoardDAO;
import a.a.a.service.FreeBoardService;
import a.a.a.util.PagingVO;

@Service("freeBoardService")
public class FreeBoardImpl implements FreeBoardService{

	
	@Resource(name="freeBoardDAO")
    private FreeBoardDAO freeBoardDAO;
	
	//게시글 등록
	@Override
	public void insertFB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		freeBoardDAO.insertFB(hm);
	}
	
	//게시글 조회
	@Override
	public HashMap<String, Object> readFB(HashMap<String, Object> map) {
		// TODO Auto-generated method stub
		return (HashMap<String,Object>) freeBoardDAO.readFB(map);

	}
	
	//게시글 수정
	@Override
	public void updateFB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		freeBoardDAO.updateFB(hm);
	}
	
	//게시글 삭제
	@Override
	public void deleteFB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		freeBoardDAO.deleteFB(hm);
	}

	//전체 게시글 개수 확인
	@Override
	public int countFB(PagingVO vo)  throws SQLException {
		// TODO Auto-generated method stub
		return freeBoardDAO.countFB(vo);
	}
	
	//페이징 처리후 게시글목록 출력
	@Override
	public ArrayList<HashMap<String, Object>> selectFB(PagingVO vo) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) freeBoardDAO.selectFB(vo);
	}
}