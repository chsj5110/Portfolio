package a.a.a.impl;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import a.a.a.dao.NoticeBoardDAO;
import a.a.a.service.NoticeBoardService;
import a.a.a.util.PagingVO;

@Service("noticeBoardService")
public class NoticeBoardImpl implements NoticeBoardService{

	
	@Resource(name="noticeBoardDAO")
    private NoticeBoardDAO noticeBoardDAO;
	
	//게시글 등록
	@Override
	public void insertNB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		noticeBoardDAO.insertNB(hm);
	}
	
	//전체 게시글 목록
	@Override
	public ArrayList<HashMap<String,Object>> NBList() throws SQLException {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String,Object>>)noticeBoardDAO.NBList();
	}
	
	//게시글 조회
	@Override
	public HashMap<String, Object> readNB(HashMap<String, Object> map) {
		// TODO Auto-generated method stub
		return (HashMap<String,Object>) noticeBoardDAO.readNB(map);

	}
	
	//게시글 수정
	@Override
	public void updateNB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		noticeBoardDAO.updateNB(hm);
	}
	
	//게시글 삭제
	@Override
	public void deleteNB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		noticeBoardDAO.deleteNB(hm);
	}
	
	//전체 게시글 개수 확인
	@Override
	public int countNB() throws SQLException {
		// TODO Auto-generated method stub
		return noticeBoardDAO.countNB();
	}
	
	//페이징 처리후 게시글목록 출력
	@Override
	public ArrayList<HashMap<String, Object>> selectNB(PagingVO vo) throws SQLException {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) noticeBoardDAO.selectNB(vo);
	}
	
    
}