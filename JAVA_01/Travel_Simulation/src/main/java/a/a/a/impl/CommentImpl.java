package a.a.a.impl;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import a.a.a.dao.CommentDAO;
import a.a.a.service.CommentService;


@Service("commentService")
public class CommentImpl implements CommentService{

	
	@Resource(name="commentDAO")
    private CommentDAO commentDAO;
	
//자유 게시판	
	//댓글 등록
	@Override
	public void insertCommentFB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		commentDAO.insertCommentFB(hm);
	}
	
	
	//댓글 목록 출력
	@Override
	public ArrayList<HashMap<String, Object>> commentListFB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) commentDAO.commentListFB(hm);
	}

	//댓글 삭제
	@Override
	public void deleteComment(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		commentDAO.deleteComment(hm);
	}

	//댓글수 확인
	@Override
	public Integer countCommentFB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (Integer) commentDAO.countCommentFB(hm);
	}
	
	
	
	
//리뷰 게시판	
	//댓글 등록
	@Override
	public void insertCommentRB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		commentDAO.insertCommentRB(hm);
	}
	
	
	//댓글 목록 출력
	@Override
	public ArrayList<HashMap<String, Object>> commentListRB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) commentDAO.commentListRB(hm);
	}
	
	
}
