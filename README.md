달리기 게임!

일단 자세히 정해진 건 없지만, 지오메트리 대시 (비주얼은 전혀 다른) 같은 느낌이 되었으면 좋겠다고 생각하고 있습니다.

먼저 캐릭터의 이동에 관해 생각해 본 건데, 먼저 Rigidbody 로 이동을 하려고 했더니 자꾸 조금씩 밀리는 게 있더라고요,, 빙판처럼 조금씩 미끄러지는 게 싫어서
그 부분을 먼저 어떻게 해봐야겠다 하고 생각했습니다.

그래서 생각해본 게 그냥 Addforce()를 쓰지 말고 velocity 자체를 좀 만져서 이동을 구현해 보려고 했습니다.

그리고 스페이스 바를 눌러서 점프를 했을 때 좀 더 높이 뛰어오른다던지 하는 점을 좀 구현해보고 싶었어요

그래서 그 이동 부분만 만지다가 시간이 다 가버렸네요..

그래서 일단은 만(?)족 할 만한 정도는 된 것 같습니다. 코드가 살짝 제 눈에 더러워 보인다는 점만 빼면요..
일단 먼저 중력을 구현하는 데 velocity에 매 프레임 중력가속도를 더해줘서 그 부분을 좀 살려보고 싶었는데 생각보다 이 부분이 조종하기가 어렵네요. 아마 mass를 좀 더 건드려야 이 부분이 달라질까요?


뭔가 횡설수설했는데 제가 처음에 생각한 캐릭터 이동은 '할로우 나이트'의 그것과 완전히 똑같이 만들어 보자! 라는 것이었습니다.
그래서 할로우 나이트(정말 어렵게 클리어한..) 을 오랜만에 다시 켜서 조작을 좀 해보고 그 감각을 느껴보고 그 감각대로 되도록 코드를 좀 머릿속에 떠올려 보고 작성하려고 했는데 아직 그렇게 완벽히 따라하진 못한 것 같네요.
이 부분에 대해서 조언 좀 주시면 감사하겠습니다....,.,.
