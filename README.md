Blazor & C# 기반 TodoList CRUD 웹 프로젝트 포트폴리오

1. 프로젝트 개요

프로젝트명: Blazor TodoList WebApp
개발 기간: 2025.02
개발 형태: 개인 
프로젝트배포: Azure 클라우드 서비스 이용
링크 : https://4.217.255.124/


2. 프로젝트 목표

본 프로젝트는 C#과 Blazor를 이용한 웹 애플리케이션 개발 경험을 쌓고, Azure를 활용하여 실제 서비스 배포까지 경험하는 것을 목표로 진행되었습니다. 저는 기존에 C#과 .NET Framework, WinForms을 활용한 Windows 응용 프로그램 개발 경험이 있으며, Java와 JavaScript 기반 웹 개발 교육을 받은 적은 있지만 실무 경험은 없었습니다.
따라서, 이 프로젝트를 통해 기존 C# 개발 경험을 웹 개발로 확장하고, Azure 클라우드 배포 경험을 쌓는 것이 주요 학습 목표였습니다.


3. 사용 기술 스택

프론트엔드: Blazor Server
백엔드: C#, .NET 8, Entity Framework Core
데이터베이스: MySQL
배포 및 호스팅: Azure Web App
기타: Stored Procedure (저장 프로시저) 활용, Dependency Injection, RESTful API


4. 주요 기능

✅ 할 일 CRUD (생성, 조회, 수정, 삭제)
: 사용자가 할 일을 추가, 수정, 삭제할 수 있는 기능을 제공
프로시저를 이용하여 MySQL 데이터베이스와 연동

✅ 완료 상태 변경 기능
: 각 할 일의 상태(완료/미완료)를 체크박스로 관리

✅ 필터링 및 정렬 기능
: 사용자가 특정 상태(완료/미완료)별 및 특정 사용자 별 할 일을 필터링 가능 

✅ Azure 배포 및 운영
: Azure Web App을 활용하여 실제 서비스 배포
MySQL 데이터베이스를 Azure에 연동하여 클라우드 환경에서 실행


5. 개발 과정 및 도전 과제

🔹 1. Blazor를 이용한 웹 개발 경험
기존에는 WinForms 기반으로 개발을 진행했으나, 이번 프로젝트에서 Blazor Server를 사용하여 컴포넌트 기반 웹 애플리케이션 개발을 경험하였습니다.
Blazor의 데이터 바인딩과 상태 관리 방식을 학습하며, 기존 WinForms와의 차이점을 비교하며 개발했습니다.

🔹 2. MySQL 및 저장 프로시저(Stored Procedure) 활용
프로젝트에서는 MSSQL을 이용한 데이터 관리를 진행하려하였으나, 하드웨어적 문제로 MySQL을 이용하였습니다. MSSQL과 MySQL의 차이점을 확인하고 비교하며 개발하였습니다.
특히, Stored Procedure를 활용한 데이터 처리 최적화를 직접 구현하고 적용하였습니다.

🔹 3. Azure를 활용한 실서비스 배포
Azure Web App을 이용하여 클라우드 환경에서 Blazor 웹앱을 호스팅하는 과정을 경험했습니다.
MySQL을 Azure에 배포하는 과정에서 발생한 DB 연결 문제를 해결하며 실무적인 배포 경험을 쌓았습니다.
GitHub을 이용한 CI/CD를 처리하고 이해하였습니다.


6. 프로젝트를 통해 얻은 것

✅ C#을 활용한 웹 개발 역량 강화
✅ Blazor 프레임워크의 기본적인 사용법 및 웹 애플리케이션 구조 이해
✅ MySQL 및 Stored Procedure 활용 경험
✅ Azure를 이용한 클라우드 배포 경험
✅ GitHub을 이용한 CI/CD 경험


7. 향후 개선 및 확장 계획

JWT 기반 사용자 인증 기능 추가 (회원가입/로그인 시스템 구축)
UI 개선 및 반응형 디자인 적용
API를 활용한 확장 가능성 탐색 (Blazor WebAssembly와의 연동 등)

