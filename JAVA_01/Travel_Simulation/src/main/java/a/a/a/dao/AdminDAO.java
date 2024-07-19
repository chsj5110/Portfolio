package a.a.a.dao;

import java.util.ArrayList;
import java.util.HashMap;

import org.springframework.stereotype.Repository;

import a.a.a.util.PagingVO;

@Repository("adminDAO")
public class AdminDAO extends AbstractDAO {

	//회원목록 출력
	public ArrayList<HashMap<String, Object>> adminMembershipList(PagingVO vo) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("admin.adminMembershipList",vo);
	}

	
	//사이트 전체 게시글 목록 보기
	public ArrayList<HashMap<String, Object>> adminBoardList(PagingVO vo) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("admin.adminBoardList", vo);
	}
	
	//자유 게시판 게시글 목록보기
	public ArrayList<HashMap<String, Object>> adminBoardListFB(PagingVO vo) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("admin.adminBoardListFB", vo);
	}

	//Q&A 게시판 게시글 목록보기
	public ArrayList<HashMap<String, Object>> adminBoardListQB(PagingVO vo) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("admin.adminBoardListQB", vo);
	}
	
	//리뷰 게시판 게시글 목록보기
	public ArrayList<HashMap<String, Object>> adminBoardListPRV(PagingVO vo) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("admin.adminBoardListPRV", vo);
	}

	//공지사항 게시글 목록 보기
	public ArrayList<HashMap<String, Object>> adminBoardListNB(PagingVO vo) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("admin.adminBoardListNB", vo);
	}

	/**
	 * 자유게시판 삭제한 게시글 복원하기
	 * @param hm
	 */
	public void restoreFB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("admin.fbRestore", hm);
	}

	/**
	 * 리뷰 게시판 삭제한 게시글 복원하기
	 * @param hm
	 */
	public void restorePRV(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("admin.prvRestore", hm);
	}

	/**
	 * Q&A 게시판 삭제한 게시글 복원하기
	 * @param hm
	 */
	public void restoreQB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("admin.qbRestore", hm);
	}

	/**
	 * 공지사항 게시판 삭제한 게시글 복원하기
	 * @param hm
	 */
	public void restoreNB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("admin.nbRestore", hm);
	}

	/**
	 * 탈퇴한 회원계정 복원하기
	 * @param hm
	 */
	public void restoreMembership(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("admin.membershipRestore", hm);
	}


	/**
	 * 게시글 수 카운팅
	 * @param hm
	 * @return
	 */
	public int countList(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (int) selectOne("admin.countFB", hm)+(int) selectOne("admin.countNB", hm)+(int) selectOne("admin.countQB", hm)+(int) selectOne("admin.countPRV", hm);
	}
	public int countListFB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (int) selectOne("admin.countFB", hm);
	}
	public int countListPRV(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (int) selectOne("admin.countPRV", hm);
	}
	public int countListQB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (int) selectOne("admin.countQB", hm);
	}
	public int countListNB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (int) selectOne("admin.countNB", hm);
	}

	
	/**
	 * 회원 수 카운팅
	 * @param map
	 * @return
	 */
	public int countMembership(HashMap<String, Object> map) {
		// TODO Auto-generated method stub
		return (int) selectOne("admin.countMembership", map);
	}

	
	/**
	 * 회원정보 조회
	 * @param hm
	 * @return
	 */
	public HashMap<String, Object> adminSelectMembership(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (HashMap<String, Object>) selectOne("admin.adminSelectMembership", hm);
	}	
}
