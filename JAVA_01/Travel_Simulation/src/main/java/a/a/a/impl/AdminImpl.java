package a.a.a.impl;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import a.a.a.dao.AdminDAO;
import a.a.a.service.AdminService;
import a.a.a.util.PagingVO;

@Service("adminService")
public class AdminImpl implements AdminService{

	@Resource(name="adminDAO")
    private AdminDAO adminDAO;
		
	@Override
	public ArrayList<HashMap<String, Object>> adminMembershipList(PagingVO vo) throws SQLException {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) adminDAO.adminMembershipList(vo);
	}

	@Override
	public ArrayList<HashMap<String, Object>> adminBoardListFB(PagingVO vo) throws SQLException {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) adminDAO.adminBoardListFB(vo);
	}

	@Override
	public ArrayList<HashMap<String, Object>> adminBoardListPRV(PagingVO vo) throws SQLException {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) adminDAO.adminBoardListPRV(vo);
	}

	@Override
	public ArrayList<HashMap<String, Object>> adminBoardListQB(PagingVO vo) throws SQLException {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) adminDAO.adminBoardListQB(vo);
	}

	@Override
	public ArrayList<HashMap<String, Object>> adminBoardListNB(PagingVO vo) throws SQLException {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) adminDAO.adminBoardListNB(vo);
	}

	
	
	@Override
	public void restoreFB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		adminDAO.restoreFB(hm);
	}

	@Override
	public void restorePRV(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		adminDAO.restorePRV(hm);
	}

	@Override
	public void restoreQB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		adminDAO.restoreQB(hm);
	}

	@Override
	public void restoreNB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		adminDAO.restoreNB(hm);
	}

	@Override
	public void restoreMembership(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		adminDAO.restoreMembership(hm);
	}



	@Override
	public ArrayList<HashMap<String, Object>> adminBoardList(PagingVO vo) throws SQLException {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) adminDAO.adminBoardList(vo);
	}

	
	//게시글 개수 카운팅
	@Override
	public int countList(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		return (int) adminDAO.countList(hm);
	}	
	@Override
	public int countListFB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		return (int) adminDAO.countListFB(hm);
	}
	@Override
	public int countListPRV(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		return (int) adminDAO.countListPRV(hm);
	}
	@Override
	public int countListQB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		return (int) adminDAO.countListQB(hm);
	}
	@Override
	public int countListNB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		return (int) adminDAO.countListNB(hm);
	}

	//회원 수 카운팅
	@Override
	public int countMembership(HashMap<String, Object> map) throws SQLException {
		// TODO Auto-generated method stub
		return adminDAO.countMembership(map);
	}

	//회원정보 조회
	@Override
	public HashMap<String, Object> adminSelectMembership(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		return adminDAO.adminSelectMembership(hm);
	}

}
