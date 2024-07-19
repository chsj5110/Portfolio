package a.a.a.impl;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import a.a.a.dao.BoardDAO;
import a.a.a.dao.CommonDAO;
import a.a.a.service.BoardService;
import a.a.a.util.PagingVO;

@Service("boardService")
public class BoardImpl implements BoardService{

	@Resource(name = "boardDAO")
	private BoardDAO boardDAO;
	@Resource(name = "commonDAO")
	private CommonDAO commonDAO;
	//리뷰 미리보기
	@Override
	public int selectReviewListCnt() throws SQLException{
		return Integer.parseInt(boardDAO.selectReviewListCnt().get("CNT").toString());
	}
	@Override
	public ArrayList<HashMap<String, Object>> selectReviewPreview() throws SQLException {
		return boardDAO.selectReviewPreview();
	}
	@Override
	public boolean insertPreview(HashMap<String, Object> hm) throws SQLException{
		boolean insertPreview = false;
		
		int i = boardDAO.insertPreview(hm);
		if(i != 0 || i == -1) {
			insertPreview = true;
		}
	return insertPreview;

	}
	
	//리뷰
	@Override
	public int ReviewListCnt(HashMap<String, Object> hm) throws SQLException{
		return Integer.parseInt(boardDAO.ReviewListCnt(hm).get("CNT").toString());
	}
	@Override
	public ArrayList<HashMap<String, Object>> selectReview(HashMap<String, Object> hm) throws SQLException {
		return boardDAO.selectReview(hm);
	}
	
	//추천 저장된 장소 불러오기
	@Override
	public ArrayList<HashMap<String, Object>> reviewRCMlist(HashMap<String, Object> hm) throws SQLException {
		return boardDAO.reviewRCMlist(hm);
	}
	@Override
	public HashMap<String, Object> placeinfo(HashMap<String, Object> hm) throws SQLException {
		return boardDAO.placeinfo(hm);
	}
	
	//리뷰 글 작성
	@Override
	public int insertRegisterSEQ() throws SQLException {
		return Integer.parseInt(boardDAO.insertRegisterSEQ().get("SEQ_PREVIEW").toString());
	}
	@Override
	public int reviewSEQ() throws SQLException {
		return Integer.parseInt(boardDAO.reviewSEQ().get("REVIEWBNO").toString());
	}
	
	@Override
	public boolean insertRegister(HashMap<String, Object> hm) throws SQLException {
		boolean insertRegister = false;
		
			int i = boardDAO.insertRegister(hm);
			if(i != 0 || i == -1) {
				insertRegister = true;
			}
		return insertRegister;
	}
	//수정
	@Override
	public HashMap<String, Object> modifydata(HashMap<String, Object> mfb) throws SQLException{
		return boardDAO.modifyData(mfb);
	}
	@Override
	public boolean updatemodify(HashMap<String, Object> upmfb) throws SQLException {
		boolean updatechk = false;
		
		int i = boardDAO.updatemodify(upmfb);
		if(i != 0 || i == -1) {
			updatechk = true;
		}
	return updatechk;
	}
	
	//평점 올리기
	@Override
	public int updategrade(HashMap<String, Object> hm) throws SQLException{

		return boardDAO.updategrade(hm);
	}
	
	@Override
	public HashMap<String, Object> avgGrade(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		return boardDAO.avgGrade(hm);
	}
	
	@Override
	public int updateAvg(HashMap<String, Object> hm) throws SQLException{
		
		System.out.println("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
		
		return boardDAO.updateAvg(hm);
	}
	
	//평점 가져오기
	@Override
	public ArrayList<HashMap<String, Object>> selectgrade(HashMap<String, Object> hm) throws SQLException {
		return boardDAO.selectgrade(hm);
	}
	
	//평점 조회
	@Override
	public HashMap<String, Object> viewgrade(HashMap<String, Object> hm) throws SQLException{
		return boardDAO.viewgrade(hm);
	}
	
	//전체 게시글 개수 확인
	@Override
	public int countPRV(PagingVO vo)  throws SQLException {
		// TODO Auto-generated method stub
		return boardDAO.countPRV(vo);
	}
	
	//페이징 처리후 게시글목록 출력
	@Override
	public ArrayList<HashMap<String, Object>> selectPRV(PagingVO vo) throws SQLException {
		return (ArrayList<HashMap<String, Object>>) boardDAO.selectPRV(vo);
	}
	


	
	@Override
	public void deleteRB(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		boardDAO.deleteRB(hm);
	}

	//나의 추천여행리스트 가져오기
	@Override
	public ArrayList<HashMap<String, Object>> tripList(HashMap<String, Object> hm) throws SQLException {
		return boardDAO.tripList(hm);
	}
	@Override
	public ArrayList<HashMap<String, Object>> RCMplacelist(HashMap<String, Object> hm) throws SQLException {
		return boardDAO.RCMplacelist(hm);
	}
	@Override
	public HashMap<String, Object> RCMplaceLatLng(HashMap<String, Object> hm) throws SQLException {
		return boardDAO.RCMplaceLatLng(hm);
	}
	@Override
	public ArrayList<HashMap<String, Object>> SelectionplaceLatLng(HashMap<String, Object> hm) throws SQLException {
		return boardDAO.SelectionplaceLatLng(hm);
	}
	@Override
	public ArrayList<HashMap<String, Object>> bookmarkselect(HashMap<String, Object> hm) throws SQLException {
		return boardDAO.bookmarkselect(hm);
	}
	@Override
	public ArrayList<HashMap<String, Object>> bookmarkinfo(HashMap<String, Object> hm) throws SQLException {
		return boardDAO.bookmarkinfo(hm);
	}
	
	//게시글의 view 증가
	@Override
	public void addViews(int index) throws SQLException {
		boardDAO.addViews(index);
		
	}

	

	
}
